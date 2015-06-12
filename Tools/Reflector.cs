using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Tools
{
    public static class Reflector
    {
        public static object ToObject(this IDictionary<string, string> input, string className)
        {
            var type = Assembly.GetExecutingAssembly().GetType(className);
            var result = Activator.CreateInstance(type);

            foreach (var pi in type.GetProperties())
            {
                var name = pi.Name;
                var val = input[name];

                switch (pi.PropertyType.Name)
                {
                    case "String":
                        pi.SetValue(result, val);
                        break;
                    case "Int32":
                        pi.SetValue(result, Int32.Parse(val));
                        break;
                    case "DateTime":
                        pi.SetValue(result, DateTime.Parse(val));
                        break;
                }
            }

            return result;
        }

        public static IDictionary<string, string> ToDictionary(this object o)
        {
            var result = new Dictionary<string, string>();

            var type = o.GetType();

            foreach (var pi in type.GetProperties())
            {
                var name = pi.Name;
                var val = pi.GetValue(o);

                switch (pi.PropertyType.Name)
                {
                    case "String":
                        result[name] = (string) val;
                        break;
                    case "Int32":
                        result[name] = val.ToString();
                        break;
                    case "DateTime":
                        result[name] = ((DateTime)val).ToString("M/d/yyyy");
                        break;
                }
            }

            return result;
        }
    }
}