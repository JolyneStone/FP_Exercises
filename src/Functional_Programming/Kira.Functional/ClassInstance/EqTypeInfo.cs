using Kira.Functional.TypeClass;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Kira.Functional.ClassInstance
{
    public struct EqTypeInfo : Eq<TypeInfo>
    {
        public bool Equals(TypeInfo x, TypeInfo y) =>
            x.Equals(y);

        public int GetHashCode(TypeInfo x) =>
            x.GetHashCode();
    }
}
