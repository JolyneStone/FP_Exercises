using System;

namespace Kira.Functional
{
    using static Kira.Functional.Functional;

    public static class ActionExtension
    {
        #region SwapArgs 交换函数参数位置

        /// <summary>
        /// 交换函数参数位置
        /// </summary>
        /// <typeparam name="T1">第一个参数类型</typeparam>
        /// <typeparam name="T2">第二个参数类型</typeparam>
        /// <param name="f">函数本体</param>
        /// <returns>交换参数后的函数体</returns>
        public static Action<T2, T1> SwapArgs<T1, T2>(this Action<T1, T2> f)
            => (t2, t1) => f(t1, t2);

        #endregion

        #region ToFunc 将Action委托转换为Func委托

        public static Func<Unit> ToFunc(this Action f)
            => () => { f(); return Functional.Unit; };

        public static Func<T1, Unit> ToFunc<T1>(this Action<T1> f)
            => t1 => { f(t1); return Functional.Unit; };

        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> f)
            => (t1, t2) => { f(t1, t2); return Functional.Unit; };

        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> f)
            => (t1, t2, t3) => { f(t1, t2, t3); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> f)
            => (t1, t2, t3, t4) => { f(t1, t2, t3, t4); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> f)
            => (t1, t2, t3, t4, t5) => { f(t1, t2, t3, t4, t5); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> f)
            => (t1, t2, t3, t4, t5, t6) => { f(t1, t2, t3, t4, t5, t6); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> f)
            => (t1, t2, t3, t4, t5, t6, t7) => { f(t1, t2, t3, t4, t5, t6, t7); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8) => { f(t1, t2, t3, t4, t5, t6, t7, t8); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15); return Functional.Unit; };

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> f)
            => (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16) => { f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16); return Functional.Unit; };

        #endregion
    }
}
