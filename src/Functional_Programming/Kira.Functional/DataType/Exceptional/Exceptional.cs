using System;
using System.Collections.Generic;
using System.Text;

namespace Kira.Functional
{
    public struct Exceptional<T>
    {
        internal Exception Ex { get; }
        internal T Value { get; }

        public bool Success => Ex == null;
        public bool Exception => Ex != null;

        internal Exceptional(Exception ex)
        {
            Ex = ex ?? throw new ArgumentNullException(nameof(ex));
            Value = default;
        }

        internal Exceptional(T right)
        {
            Value = right;
            Ex = null;
        }

        public static implicit operator Exceptional<T>(Exception left) => new Exceptional<T>(left);
        public static implicit operator Exceptional<T>(T right) => new Exceptional<T>(right);
        public static implicit operator Either<Exception, T>(Exceptional<T> exceptional) =>
            exceptional.Exception ?
            new Either<Exception, T>(exceptional.Ex) :
            new Either<Exception, T>(exceptional.Value);

        public static implicit operator Exceptional<T>(Either<Exception, T> either) =>
          either.IsLeft ?
          new Either<Exception, T>(either.Left) :
          new Either<Exception, T>(either.Right);

        public TR Match<TR>(Func<Exception, TR> Exception, Func<T, TR> Success)
           => this.Exception ? Exception(Ex) : Success(Value);

        public Unit Match(Action<Exception> Exception, Action<T> Success)
           => Match(Exception.ToFunc(), Success.ToFunc());

        public override string ToString()
           => Match(
              ex => $"Exception({ex.Message})",
              t => $"Success({t})");
    }
}
