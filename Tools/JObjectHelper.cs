using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SimplePad
{
    public static class JObjectHelper
    {
        public static string GetString(JToken data, string key)
        {
            string result = null;
            if (data == null || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }

            if (data[key] != null)
            {
                result = data[key].Value<string>();
            }
            return result;
        }

        public static int GetInt(JToken data, string key, int defaultValue)
        {
            int result = defaultValue;
            if (data == null || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }

            if (data[key] != null)
            {
                result = data[key].Value<int>();
            }
            return result;
        }

        public static bool GetBool(JToken data, string key, bool defaultValue)
        {
            bool result = defaultValue;
            if (data == null || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }

            if (data[key] != null)
            {
                result = data[key].Value<bool>();
            }
            return result;
        }

        public static List<JToken> GetList(JToken data, string key)
        {
            List<JToken> result = null;
            if (data == null || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }

            if (data[key] != null)
            {
                result = data[key].Children().ToList<JToken>(); ;
            }
            return result;
        }
    }
}
