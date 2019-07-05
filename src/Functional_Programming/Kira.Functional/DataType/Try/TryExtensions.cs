using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kira.Functional
{
    public static class TryExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exceptional<T> Run<T>(this Try<T> @try)
        {
            try { return @try(); }
            catch (Exception ex) { return ex; }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<R> Map<T, R>
           (this Try<T> @try, Func<T, R> f)
           => ()
           => @try.Run()
                 .Match<Exceptional<R>>(
                    ex => ex,
                    t => f(t));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, R>> Map<T1, T2, R>
           (this Try<T1> @try, Func<T1, T2, R> func)
           => @try.Map(func.Curry());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, R>> Map<T1, T2, T3, R>
             (this Try<T1> @try, Func<T1, T2, T3, R> func)
             => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, R>> Map<T1, T2, T3, T4, R>
             (this Try<T1> @try, Func<T1, T2, T3, T4, R> func)
             => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, R>> Map<T1, T2, T3, T4, T5, R>
           (this Try<T1> @try, Func<T1, T2, T3, T4, T5, R> func)
           => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, R>> Map<T1, T2, T3, T4, T5, T6, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, R>> Map<T1, T2, T3, T4, T5, T6, T7, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>
            (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> func)
            => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>
           (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> func)
           => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>
           (this Try<T1> @try, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> func)
           => @try.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<R> Bind<T, R>
           (this Try<T> @try, Func<T, Try<R>> f)
           => ()
           => @try.Run().Match(
                 Exception: ex => ex,
                 Success: t => f(t).Run());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<R> Select<T, R>(this Try<T> @this, Func<T, R> func) => @this.Map(func);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<RR> SelectMany<T, R, RR>
           (this Try<T> @try, Func<T, Try<R>> bind, Func<T, R, RR> project)
           => ()
           => @try.Run().Match(
                 ex => ex,
                 t => bind(t).Run()
                          .Match<Exceptional<RR>>(
                             ex => ex,
                             r => project(t, r))
                          );
    }
}
