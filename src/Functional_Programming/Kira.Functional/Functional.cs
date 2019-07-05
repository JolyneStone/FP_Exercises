using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kira.Functional
{
    public static partial class Functional
    {
        public static Option.None None => Kira.Functional.Option.None.Default;

        public static Unit Unit => default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<T> Option<T>(T value) => value == null ? None : (Option<T>)new Option.Some<T>(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Error Error(string message) => new Error(message);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation<T> Valid<T>(T value) => new Validation<T>(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation.Invalid Invalid(params Error[] errors) =>
            new Validation.Invalid(errors);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation<R> Invalid<R>(params Error[] errors) =>
            new Validation.Invalid(errors);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation.Invalid Invalid(IEnumerable<Error> errors) =>
            new Validation.Invalid(errors);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Validation<R> Invalid<R>(IEnumerable<Error> errors) =>
            new Validation.Invalid(errors);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> Async<T>(T t) => Task.FromResult(t);

        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> f)
            where TDisp : IDisposable
        {
            using (disposable)
                return f(disposable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Unit Using<TDisp, R>(TDisp disposable, Action<TDisp> f)
            where TDisp : IDisposable
        {
            using (disposable)
                f(disposable);
            return Unit;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Using<TDisp, R>(Func<TDisp> createDisposable
           , Func<TDisp, R> func) where TDisp : IDisposable
        {
            using (var disp = createDisposable())
                return func(disp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Unit Using<TDisp>(Func<TDisp> createDisposable
           , Action<TDisp> action) where TDisp : IDisposable
        {
            using (var disp = createDisposable())
                action(disp);
            return Unit;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, R>> Curry<T1, T2, R>(this Func<T1, T2, R> func) =>
            t1 => t2 => func(t1, t2);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, R>>> Curry<T1, T2, T3, R>(this Func<T1, T2, T3, R> func) =>
            t1 => t2 => t3 => func(t1, t2, t3);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, R>>>> Curry<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func) =>
                t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, R>>>>> Curry<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> func) =>
              t1 => t2 => t3 => t4 => t5 => func(t1, t2, t3, t4, t5);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, R>>>>>> Curry<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> func) =>
             t1 => t2 => t3 => t4 => t5 => t6 => func(t1, t2, t3, t4, t5, t6);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, R>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => func(t1, t2, t3, t4, t5, t6, t7, t8);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, R>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, R>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, R>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, R>>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, R>>>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, R>>>>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => t14 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, R>>>>>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => t14 => t15 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, Func<T16, R>>>>>>>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> func) =>
            t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => t14 => t15 => t16 => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, R>> CurryFirst<T1, T2, T3, R>(this Func<T1, T2, T3, R> @this) =>
            t1 => (t2, t3) => @this(t1, t2, t3);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, R>> CurryFirst<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> @this) =>
            t1 => (t2, t3, t4) => @this(t1, t2, t3, t4);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, R>> CurryFirst<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> @this) =>
            t1 => (t2, t3, t4, t5) => @this(t1, t2, t3, t4, t5);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, R>> CurryFirst<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> @this) =>
            t1 => (t2, t3, t4, t5, t6) => @this(t1, t2, t3, t4, t5, t6);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, R>(this Func<T1, T2, T3, T4, T5, T6, T7, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7) => @this(t1, t2, t3, t4, t5, t6, t7);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8) => @this(t1, t2, t3, t4, t5, t6, t7, t8);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> @this) =>
            t1 => (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16) => @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, T> Tap<T>(Action<T> act)
           => x => { act(x); return x; };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Map<T, R>(T value, Func<T, R> project) =>
            project(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Map<T1, T2, R>(T1 value1, T2 value2, Func<T1, T2, R> project) =>
            project(value1, value2);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Map<T1, T2, T3, R>(T1 value1, T2 value2, T3 value3, Func<T1, T2, T3, R> project) =>
            project(value1, value2, value3);

        [Pure]
        public static R Map<T1, T2, T3, T4, R>(T1 value1, T2 value2, T3 value3, T4 value4, Func<T1, T2, T3, T4, R> project) =>
            project(value1, value2, value3, value4);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Map<T1, T2, T3, T4, T5, R>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, Func<T1, T2, T3, T4, T5, R> project) =>
            project(value1, value2, value3, value4, value5);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, Option<R>> With<T, R>(T value, Func<T, R> map) =>
            (T input) =>
                EqualityComparer<T>.Default.Equals(input, value)
                    ? Some(map(input))
                    : None;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<Exception, Option<R>> With<T, R>(Func<T, R> map)
            where T : Exception =>
            (Exception input) =>
                input is T
                    ? Some(map((T)input))
                    : None;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, Option<R>> Otherwise<T, R>(Func<T, R> map) =>
            (T input) => Some(map(input));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static B Match<T, B>(T value, params Func<T, Option<B>>[] clauses)
        {
            foreach (var clause in clauses)
            {
                var res = clause(value);
                if (res.IsSome) return res.Value;
            }
            throw new Exception("Match not exhaustive");
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, B> Function<T, B>(params Func<T, Option<B>>[] clauses) => (T value) =>
        {
            foreach (var clause in clauses)
            {
                var res = clause(value);
                if (res.IsSome) return res.Value;
            }

            throw new Exception("Match not exhaustive");
        };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Identity<T>(T x) =>
            x;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Action Failwith(string message) =>
            () => throw new Exception(message);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Failwith<R>(string message) =>
            throw new Exception(message);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Raiseapp<R>(string message) =>
            throw new ApplicationException(message);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Raise<R>(Exception ex) =>
            throw ex;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ExceptionIs<E>(Exception e)
        {
            if (e is E) return true;
            if (e.InnerException == null) return false;
            return ExceptionIs<E>(e.InnerException);
        }

        public static int Hash<T>(IEnumerable<T> xs)
        {
            if (xs == null) return 0;
            unchecked
            {
                int hash = 1;
                foreach (var x in xs)
                {
                    hash = ReferenceEquals(x, null)
                        ? hash * 31
                        : hash * 31 + x.GetHashCode();
                }
                return hash;
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, bool> Not<T>(Func<T, bool> f) =>
            x => !f(x);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, B, bool> Not<T, B>(Func<T, B, bool> f) =>
            (x, y) => !f(x, y);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, B, C, bool> Not<T, B, C>(Func<T, B, C, bool> f) =>
            (x, y, z) => !f(x, y, z);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Not(bool value) =>
            !value;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefault<T>(T value) =>
            ObjectExtensions.Check<T>.IsDefault(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotDefault<T>(T value) =>
            !ObjectExtensions.Check<T>.IsDefault(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<T>(T value) =>
            ObjectExtensions.Check<T>.IsNull(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotNull<T>(T value) =>
            !ObjectExtensions.Check<T>.IsNull(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(IEnumerable<T> value) =>
            ObjectExtensions.Check<IEnumerable<T>>.IsNull(value) || !value.Any();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty<T>(IEnumerable<T> value) =>
            !ObjectExtensions.Check<IEnumerable<T>>.IsNull(value) && value.Any();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Pipe<T, R>(this T @this, Func<T, R> func) => func(@this);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Pipe<T>(this T input, Action<T> func) => Tap(func)(input);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KeyValuePair<K, T> Pair<K, T>(K key, T value)
           => new KeyValuePair<K, T>(key, value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> List<T>(params T[] items) => items.ToImmutableList();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, IEnumerable<T>> SingletonList<T>() => (item) => ImmutableList.Create(item);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> Cons<T>(this T t, IEnumerable<T> ts)
           => List(t).Concat(ts);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, IEnumerable<T>, IEnumerable<T>> Cons<T>()
           => (t, ts) => t.Cons(ts);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IDictionary<K, T> Map<K, T>(params KeyValuePair<K, T>[] pairs)
           => pairs.ToImmutableDictionary();

        [Pure]
        public static string ToString<T>(T value) =>
            value?.ToString() ?? "";

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Either.Left<L> Left<L>(L l) => new Either.Left<L>(l);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Either.Right<R> Right<R>(R r) => new Either.Right<R>(r);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Try<T> Try<T>(Func<T> f) => () => f();

    }
}
