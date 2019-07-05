using Kira.Functional.TypeClass;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;

namespace Kira.Functional.ClassInstance
{
    public struct OrdDefault<T> : Ord<T>
    {
        public static readonly OrdDefault<T> Inst = default(OrdDefault<T>);

        [Pure]
        public int Compare(T x, T y) => Comparer.Compare(x, y);

        [Pure]
        public bool Equals(T x, T y) =>
            default(EqDefault<T>).Equals(x, y);

        [Pure]
        public int GetHashCode(T x) =>
            default(EqDefault<T>).GetHashCode(x);

        static readonly bool IsFunc =
            typeof(T).GetTypeInfo().ToString().StartsWith("System.Func") ||
            typeof(T).GetTypeInfo().ToString().StartsWith("<>");

        static readonly IComparer<T> Comparer =
            IsFunc
                ? new DelCompare() as IComparer<T>
                : Comparer<T>.Default;

        class DelCompare : IComparer<T>
        {
            public int Compare(T x, T y) =>
                ReferenceEquals(x, y) ? 0 : -1;
        }
    }
}
