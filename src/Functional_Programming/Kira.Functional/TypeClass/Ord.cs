using Kira.Functional.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Kira.Functional.TypeClass
{
    [TypeClass]
    public interface Ord<A> : Eq<A>
    {
        [Pure]
        int Compare(A x, A y);
    }
}
