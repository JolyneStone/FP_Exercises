using Kira.Functional.TypeClass;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Kira.Functional.ClassInstance
{
    public struct OrdTypeInfo : Ord<TypeInfo>
    {
        public int Compare(TypeInfo x, TypeInfo y) =>
            x.ToString().CompareTo(y.ToString());

        public bool Equals(TypeInfo x, TypeInfo y) =>
            default(EqTypeInfo).Equals(x, y);

        public int GetHashCode(TypeInfo x) =>
            default(EqTypeInfo).GetHashCode(x);
    }
}
