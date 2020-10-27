using System;
using System.Reflection;

namespace Utility.Reflection
{
    public static class ReflectionExtensions
    {
        public static object Invoke(this ConstructorInfo constructorInfo)
        {
            if (constructorInfo == null)
            {
                throw new ArgumentNullException(nameof(constructorInfo));
            }

            return constructorInfo.Invoke(null);
        }

        public static object GetValue(this FieldInfo fieldInfo)
        {
            if (fieldInfo == null)
            {
                throw new ArgumentNullException(nameof(fieldInfo));
            }

            return fieldInfo.GetValue(null);
        }

        public static void SetValue(this FieldInfo fieldInfo, object value)
        {
            if (fieldInfo == null)
            {
                throw new ArgumentNullException(nameof(fieldInfo));
            }

            fieldInfo.SetValue(null, value);
        }

        public static object Invoke(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            return methodInfo.Invoke(null, null);
        }
        public static object Invoke(this MethodInfo methodInfo, object instance)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return methodInfo.Invoke(instance, null);
        }
        public static object Invoke(this MethodInfo methodInfo, object[] parameters)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return methodInfo.Invoke(null, parameters);
        }

        public static T CreateDelegate<T>(this MethodInfo methodInfo, object instance = null)
            where T : Delegate
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            return (T)methodInfo.CreateDelegate(typeof(T), instance);
        }

        public static object GetValue(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            return propertyInfo.GetValue(null);
        }

        public static void SetValue(this PropertyInfo propertyInfo, object value)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            propertyInfo.SetValue(null, value, null);
        }
        public static void SetValue(this PropertyInfo propertyInfo, object value, object[] index)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            propertyInfo.SetValue(null, value, index);
        }
    }
}