using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kira.Functional
{
    public static class ObjectExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefault<A>(this A value) =>
            Check<A>.IsDefault(value);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<T>(this T value) =>
            Check<T>.IsNull(value);

        internal static class Check<T>
        {
            static readonly bool IsReferenceType;
            static readonly bool IsNullable;
            static readonly EqualityComparer<T> DefaultEqualityComparer;

            static Check()
            {
                IsNullable = Nullable.GetUnderlyingType(typeof(T)) != null;
                IsReferenceType = !typeof(T).GetTypeInfo().IsValueType;
                DefaultEqualityComparer = EqualityComparer<T>.Default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool IsDefault(T value) =>
                DefaultEqualityComparer.Equals(value, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool IsNull(T value) =>
                (IsReferenceType && value == null) || (IsNullable && value.Equals(default));
        }
    }
}
