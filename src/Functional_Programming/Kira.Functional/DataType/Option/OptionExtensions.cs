using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Linq;
using Kira.Functional.Option;
using System.Threading.Tasks;

namespace Kira.Functional
{
    using static Functional;

    public static class OptionExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<A> Somes<A>(this IEnumerable<Option<A>> self)
        {
            foreach (var item in self)
            {
                if (item.IsSome)
                {
                    yield return item.Value;
                }
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Apply<T, R>(this Option<Func<T, R>> @this, Option<T> arg) =>
            @this.Match(
                () => None,
                func => arg.Match(
                    () => None,
                    val => Some(func(val))));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<Func<T2, R>> Apply<T1, T2, R>(this Option<Func<T1, T2, R>> @this, Option<T1> arg) =>
            Apply(@this.Map(Functional.Curry), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<Func<T2, T3, R>> Apply<T1, T2, T3, R>(this Option<Func<T1, T2, T3, R>> @this, Option<T1> arg) =>
            Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToNullable<T>(this Option<T> ma) where T : struct =>
            ma.IsNone
                ? (T?)null
                : ma.Value;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Bind<T, R>
           (this Option<T> optT, Func<T, Option<R>> f)
            => optT.Match(
               () => None,
               (t) => f(t));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Bind<T, R>
            (this Option<T> optT, Func<T, R> f)
            => optT.Match(
                () => None,
                (t) => Some(f(t)));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<R> Bind<T, R>
           (this Option<T> @this, Func<T, IEnumerable<R>> func)
            => @this.AsEnumerable().Bind(func);

        public static Option<Unit> ForEach<T>(this Option<T> @this, Action<T> action)
           => Map(@this, action.ToFunc());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Map<T, R>(this None opt,
           Func<T, R> f) => None;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Map<T, R>(this Some<T> opt,
           Func<T, R> f) => Some(f(opt.Value));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Map<T, R>(this Option<T> opt,
           Func<T, R> f) =>
           Match(opt,
               t => Some(f(t)),
               () => None);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Match<T, R>(this Option<T> opt,
         Func<T, R> Some,
         Func<R> None) =>
         IsNull(opt) || opt.IsNone
             ? None()
             : Some(opt.Value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Match<T, R>(this Option<T> opt,
             Func<T, Option<R>> Some,
             Func<Option<R>> None) =>
             IsNull(opt) || opt.IsNone
                 ? None()
                 : Some(opt.Value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Option<R>> Match<T, R>(this IEnumerable<Option<T>> list,
            Func<IEnumerable<Option<T>>, IEnumerable<Option<R>>> Some,
            Func<IEnumerable<Option<R>>> None) =>
            IsEmpty(list)
                ? None()
                : Some(list);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Option<R>> Match<T, R>(this IEnumerable<Option<T>> list,
            Func<IEnumerable<Option<T>>, IEnumerable<Option<R>>> Some,
            IEnumerable<Option<R>> None) =>
            IsEmpty(list)
                ? None
                : Some(list);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Option<R>> Match<T, R>(this IEnumerable<Option<T>> list,
          Func<Option<T>, Option<R>> Some,
          Func<Option<R>> None) =>
          IsEmpty(list)
              ? new List<Option<R>>() { None() }
              : list.Select(p => IsNull(p) || p.IsNone
              ? None()
              : Some(p));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Option<R>> Match<T, R>(this IEnumerable<Option<T>> list,
         Func<Option<T>, Option<R>> Some,
         Option<R> None) =>
         IsEmpty(list)
             ? new List<Option<R>>() { None }
             : list.Select(p => IsNull(p) || p.IsNone
             ? None
             : Some(p));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ValueUnsafe<T>(this Option<T> @this)
         => @this.Match(
            () => { throw new InvalidOperationException(); },
            (t) => t);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrElse<T>(this Option<T> opt, T defaultValue)
           => opt.Match(
              () => defaultValue,
              (t) => t);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrElse<T>(this Option<T> opt, Func<T> fallback)
           => opt.Match(
              () => fallback(),
              (t) => t);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> GetOrElse<T>(this Option<T> opt, Func<Task<T>> fallback)
           => opt.Match(
              () => fallback(),
              (t) => Async(t));

        public static Option<T> OrElse<T>(this Option<T> left, Option<T> right)
           => left.Match(
              () => right,
              (_) => left);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<T> OrElse<T>(this Option<T> left, Func<Option<T>> right)
           => left.Match(
              () => right(),
              (_) => left);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation<T> ToValidation<T>(this Option<T> opt, Func<Error> error)
           => opt.Match(
              () => Invalid(error()),
              (t) => Valid(t));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<R> Select<T, R>(this Option<T> @this, Func<T, R> func)
           => @this.Map(func);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<T> Where<T>
           (this Option<T> optT, Func<T, bool> predicate)
           => optT.Match(
              () => None,
              (t) => predicate(t) ? optT : None);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<RR> SelectMany<T, R, RR>
           (this Option<T> opt, Func<T, Option<R>> bind, Func<T, R, RR> project)
           => opt.Match(
              () => None,
              (t) => bind(t).Match(
                 () => None,
                 (r) => Some(project(t, r))));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static U CheckNullReturn<U>(U value, string location) =>
            IsNull(value)
                ? throw new ArgumentNullException($"'{location}' result is null.  Not allowed.")
                : value;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static U CheckNullNoneReturn<U>(U value) =>
            CheckNullReturn(value, "None");

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static U CheckNullSomeReturn<U>(U value) =>
            CheckNullReturn(value, "Some");
    }
}
