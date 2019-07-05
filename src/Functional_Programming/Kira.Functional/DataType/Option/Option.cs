using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Kira.Functional
{
    using Kira.Functional.ClassInstance;
    using Kira.Functional.Option;
    using Kira.Functional.TypeClass;
    using System.Collections;
    using System.Runtime.CompilerServices;

    [Serializable]
    public struct Option<T> : IEquatable<None>,
        IEquatable<Option<T>>,
        IComparable<Option<T>>,
        IEnumerable<T>,
        ISerializable
    {
        private readonly T _value;
        private readonly bool _isSome;

        [Pure]
        public bool IsNone => !_isSome;

        [Pure]
        public bool IsSome => _isSome;

        public T Value => _isSome ? _value : default;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            this._isSome = true;
            this._value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value)
           => value == null ? Functional.None : Functional.Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value) : None();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome) yield return _value;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => _isSome ? $"Some({_value})" : "None";

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<T> GetEnumerator() => AsEnumerable().GetEnumerator();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() => AsEnumerable().GetEnumerator();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(Option<T> other) =>
            CompareTo<OrdDefault<T>>(other);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo<OrdA>(Option<T> other) where OrdA : struct, Ord<T>
        {
            var yIsSome = other.IsSome;
            var xIsNone = !_isSome;
            var yIsNone = !yIsSome;

            if (xIsNone && yIsNone) return 0;
            if (_isSome && yIsNone) return 1;
            if (xIsNone && yIsSome) return -1;

            return default(OrdA).Compare(Value, other.Value);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Option<T>)obj);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Option.None _) => !_isSome;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Option<T> other) 
            => this._isSome == other._isSome && (!this._isSome || this._value.Equals(other.Value));


        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals<EqA>(Option<T> other) where EqA : struct, Eq<T>
        {
            var yIsSome = other.IsSome;
            var xIsNone = !_isSome;
            var yIsNone = !yIsSome;
            return (xIsNone && yIsNone) || (_isSome && yIsSome && default(EqA).Equals(_value, other.Value));
        }

        [Pure]
        public override int GetHashCode() =>
          _isSome
          ? Value.GetHashCode()
          : 0;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsSome", IsSome);
            if(IsSome) info.AddValue("Value", Value);
        }
    }

    namespace Option
    {
        public struct None
        {
            public static readonly None Default = new None();
        }

        public struct Some<T>
        {
            public T Value { get; }

            public Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value)
                       , "Cannot wrap a null value in a 'Some'; use 'None' instead");
                Value = value;
            }
        }
    }
}
