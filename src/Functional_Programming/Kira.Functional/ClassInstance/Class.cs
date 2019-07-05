using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kira.Functional.ClassInstance
{
    public static class Class<T> where T: new()
    {
        public readonly static T Default;

        static Class()
        {
            Default = new T();
        }
    }
}
