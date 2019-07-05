using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kira.Functional
{
    using static Kira.Functional.Functional;

    public static class TaskExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<R> Apply<T, R>
         (this Task<Func<T, R>> f, Task<T> arg)
         //=> (await f)(await arg);
         => (await f.ConfigureAwait(false))(await arg.ConfigureAwait(false));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, R>> Apply<T1, T2, R>
           (this Task<Func<T1, T2, R>> f, Task<T1> arg)
           => Apply(f.Map(Functional.Curry), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, R>> Apply<T1, T2, T3, R>
           (this Task<Func<T1, T2, T3, R>> @this, Task<T1> arg)
           => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, R>> Apply<T1, T2, T3, T4, R>
           (this Task<Func<T1, T2, T3, T4, R>> @this, Task<T1> arg)
           => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, R>> Apply<T1, T2, T3, T4, T5, R>
           (this Task<Func<T1, T2, T3, T4, T5, R>> @this, Task<T1> arg)
           => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, R>> Apply<T1, T2, T3, T4, T5, T6, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, R>> Apply<T1, T2, T3, T4, T5, T6, T7, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>
            (this Task<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> @this, Task<T1> arg)
            => Apply(@this.Map(Functional.CurryFirst), arg);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<R> Map<T, R>
           (this Task<T> task, Func<T, R> f)
           //=> f(await task);
           => f(await task.ConfigureAwait(false));

        public static async Task<R> Map<R>
           (this Task task, Func<R> f)
        {
            await task;
            return f();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, R>> Map<T1, T2, R>
           (this Task<T1> @this, Func<T1, T2, R> func)
            => @this.Map(func.Curry());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, R>> Map<T1, T2, T3, R>
           (this Task<T1> @this, Func<T1, T2, T3, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, R>> Map<T1, T2, T3, T4, R>
           (this Task<T1> @this, Func<T1, T2, T3, T4, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, R>> Map<T1, T2, T3, T4, T5, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, R>> Map<T1, T2, T3, T4, T5, T6, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, R>> Map<T1, T2, T3, T4, T5, T6, T7, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, R>
             (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func)
             => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>
            (this Task<T1> @this, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> func)
            => @this.Map(func.CurryFirst());

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<R> Map<T, R>
           (this Task<T> task, Func<Exception, R> Faulted, Func<T, R> Completed)
           => task.ContinueWith(t =>
                 t.Status == TaskStatus.Faulted
                    ? Faulted(t.Exception)
                    : Completed(t.Result));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Unit> ForEach<T>(this Task<T> @this, Action<T> continuation)
            => @this.ContinueWith(t => continuation.ToFunc()(t.Result)
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<R> Bind<T, R>
           (this Task<T> task, Func<T, Task<R>> f)
            //=> await f(await task);
            => await f(await task.ConfigureAwait(false)).ConfigureAwait(false);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> OrElse<T>
           (this Task<T> task, Func<Task<T>> fallback)
           => task.ContinueWith(t =>
                 t.Status == TaskStatus.Faulted
                    ? fallback()
                    : Task.FromResult(t.Result)
              )
              .Unwrap();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> Recover<T>
           (this Task<T> task, Func<Exception, T> fallback)
           => task.ContinueWith(t =>
                 t.Status == TaskStatus.Faulted
                    ? fallback(t.Exception)
                    : t.Result);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> RecoverWith<T>
           (this Task<T> task, Func<Exception, Task<T>> fallback)
           => task.ContinueWith(t =>
                 t.Status == TaskStatus.Faulted
                    ? fallback(t.Exception)
                    : Task.FromResult(t.Result)
           ).Unwrap();


        public static async Task<RR> SelectMany<T, R, RR>
           (this Task<T> task, Func<T, Task<R>> bind, Func<T, R, RR> project)
        {
            T t = await task;
            R r = await bind(t);
            return project(t, r);
        }

        public static async Task<RR> SelectMany<R, RR>
           (this Task task, Func<Unit, Task<R>> bind, Func<Unit, R, RR> project)
        {
            await task;
            R r = await bind(Functional.Unit);
            return project(Functional.Unit, r);
        }

             [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<R> Select<T, R>(this Task<T> task, Func<T, R> f)
           => f(await task);

        public static async Task<T> Where<T>(this Task<T> source
            , Func<T, bool> predicate)
        {
            T t = await source;
            if (!predicate(t)) throw new OperationCanceledException();
            return t;
        }

        public static async Task<V> Join<T, U, K, V>(
            this Task<T> source, Task<U> inner,
            Func<T, K> outerKeySelector, Func<U, K> innerKeySelector,
            Func<T, U, V> resultSelector)
        {
            await Task.WhenAll(source, inner);
            if (!EqualityComparer<K>.Default.Equals(
                outerKeySelector(source.Result), innerKeySelector(inner.Result)))
                throw new OperationCanceledException();
            return resultSelector(source.Result, inner.Result);
        }

        public static async Task<V> GroupJoin<T, U, K, V>(
            this Task<T> source, Task<U> inner,
            Func<T, K> outerKeySelector, Func<U, K> innerKeySelector,
            Func<T, Task<U>, V> resultSelector)
        {
            T t = await source;
            return resultSelector(t,
                inner.Where(u => EqualityComparer<K>.Default.Equals(
                    outerKeySelector(t), innerKeySelector(u))));
        }
    }
}
