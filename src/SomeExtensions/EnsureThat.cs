using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SomeExtensions
{
#if NET7_0_OR_GREATER
    public static class EnsureThat
    {
        //[Caller]
        public static void ItIsEmpty<T>(IEnumerable<T> value, [CallerArgumentExpression("value")] string message = "")
        {
            if (value.Any())
            {
                throw new ArgumentException("Enumerable is not empty", message);
            }
        }

        public static void ItIsNotEmpty<T>(IEnumerable<T> value, [CallerArgumentExpression("value")] string message = "")
        {
            if (!value.Any())
            {
                throw new ArgumentException("Enumerable is empty", message);
            }
        }

        public static void ItIsNull<T>(T value, [CallerArgumentExpression("value")] string message = "")
        {
            if (value != null)
            {
                throw new ArgumentException("Value is not null", message);
            }
        }
        public static void ItIsNotNull<T>(T value, [CallerArgumentExpression("value")] string message = "")
        {
            if (value == null)
            {
                throw new ArgumentException("Value is null", message);
            }
        }

        public static void ItIsTrue(bool value, [CallerArgumentExpression("value")] string message = "")
        {
            if (!value)
            {
                throw new ArgumentException("Value is ot true", message);
            }
        }
        public static void ItIsTrue(Func<bool> value, [CallerArgumentExpression("value")] string message = "")
        {
            if (!value())
            {
                throw new ArgumentException("Value is ot true", message);
            }
        }
    }
#endif
}