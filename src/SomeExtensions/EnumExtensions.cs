using System;
using System.Linq;
//using System.ComponentModel.ann;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SomeExtensions
{
    public static class EnumExtensions
    {
        public static string Name(this Enum enumType)
        {
            var res = enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>();
            return res == null ? enumType.ToString() : res.Name ?? enumType.ToString();
        }

        public static string ShortName(this Enum enumType)
        {
            var res = enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>();
            return res == null ? enumType.ToString() : res.ShortName ?? enumType.ToString();
        }

        public static string Description(this Enum enumType)
        {
            var res = enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>();
            return res == null ? enumType.ToString() : res.Description?? enumType.ToString();
        }

        public static List<string> Names<T>() //where T : Enum
        {
            //var q = T as Enum;
            var f = Enum.GetValues(typeof(T));
            var ll = f.Cast<Enum>();
            return ll.Select(x => x.Name()).ToList();


        }

        public static T GetValueFromName<T>(this string name) //where T : Enum
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute)
                {
                    var atr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                    if (atr != null)
                    {
                        if (atr.Name == name)
                        {
                            return (T)field.GetValue(null);
                        }
                    }
                }

                if (field.Name == name)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}