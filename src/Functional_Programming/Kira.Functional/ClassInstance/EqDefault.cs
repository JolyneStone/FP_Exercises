using Kira.Functional.TypeClass;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;

namespace Kira.Functional.ClassInstance
{
    using static Functional;

    public struct EqDefault<T> : Eq<T>
    {
        public static readonly EqDefault<T> Inst = default(EqDefault<T>);

        [Pure]
        public bool Equals(T a, T b)
        {
            if (IsNull(a)) return IsNull(b);
            if (IsNull(b)) return false;
            if (ReferenceEquals(a, b)) return true;
            return Comparer.Equals(a, b);
        }

        [Pure]
        public int GetHashCode(T x) =>
             IsFunc
                ? x.IsNull() ? 0 : Comparer.GetHashCode(x)
                : (x.IsNull() ? 0 : Comparer.GetHashCode(x));

        static readonly bool IsFunc =
            typeof(T).GetTypeInfo().ToString().StartsWith("System.Func") ||
            typeof(T).GetTypeInfo().ToString().StartsWith("<>");

        static readonly IEqualityComparer<T> Comparer =
            IsFunc
                ? new DelEq() as IEqualityComparer<T>
                : EqualityComparer<T>.Default;

        class DelEq : IEqualityComparer<T>
        {
            public bool Equals(T x, T y) =>
                ReferenceEquals(x, y);

            public int GetHashCode(T x) =>
                x?.GetHashCode() ?? 0;
        }
    }
}
