using System;
using System.Collections.Generic;
using System.Text;

namespace Kira.Functional
{
    public class Error
    {
        public virtual string Message { get; }
        public override string ToString() => Message;
        protected Error() { }
        internal Error(string Message) { this.Message = Message; }

        public static implicit operator Error(string m) => new Error(m);
    }
}
