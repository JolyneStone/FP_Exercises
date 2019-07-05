using Kira.Functional.Attributes;
using System.Diagnostics.Contracts;

namespace Kira.Functional.TypeClass
{
    [TypeClass]
    public interface Eq<A>
    {
        [Pure]
        bool Equals(A x, A y);

        [Pure]
        int GetHashCode(A x);
    }
}