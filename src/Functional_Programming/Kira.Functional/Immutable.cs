using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Kira.Functional
{
    public static class Immutable
    {
        public static T With<T>(this T source, string memberName, object newValue)
           where T : class
        {
            T @new = source.ShallowCopy();

            GetField(typeof(T), memberName)
               .SetValue(@new, newValue);

            return @new;
        }

        /// <summary>
        /// 更新旧对象状态，返回新对象
        /// </summary>
        /// <returns>新对象</returns>
        public static T With<T, P>(this T source, Expression<Func<T, P>> exp, object newValue)
           where T : class
           => source.With(exp.MemberName(), newValue);

        private static string MemberName<T, P>(this Expression<Func<T, P>> e)
           => ((MemberExpression)e.Body).Member.Name;

        private static T ShallowCopy<T>(this T source)
           => (T)source.GetType().GetMethod("MemberwiseClone"
                 , BindingFlags.Instance | BindingFlags.NonPublic)
              .Invoke(source, null);

        private static string BackingFieldName(string propertyName)
           => string.Format("<{0}>k__BackingField", propertyName); // k__BackingField为C#自动属性所生成字段的默认形式

        private static FieldInfo GetField(this Type t, string memberName)
        {
            var type = t.GetTypeInfo();
            return type.GetField(BackingFieldName(memberName), BindingFlags.Instance | BindingFlags.NonPublic) ?? 
                type.GetField(memberName, BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}
