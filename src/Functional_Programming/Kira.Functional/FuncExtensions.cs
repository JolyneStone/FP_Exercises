using System;

namespace Kira.Functional
{
    public static class FuncExtensions
    {
        #region SwapArgs 交换函数参数位置

        /// <summary>
        /// 交换函数参数位置
        /// </summary>
        /// <typeparam name="T1">第一个参数类型</typeparam>
        /// <typeparam name="T2">第二个参数类型</typeparam>
        /// <typeparam name="R">函数返回类型</typeparam>
        /// <param name="f">函数本体</param>
        /// <returns>交换参数后的函数体</returns>
        public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> f)
            => (t2, t1) => f(t1, t2);

        #endregion
    }
}
