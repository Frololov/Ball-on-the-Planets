using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;


namespace BallOnPlanet.Data
{
    public class Storage
    {
        private static string GetPrefsKey(string path, string valueName)
        {
            return $"{path}.{valueName}";
        }

        public static void Save<T>(T data, string path)
        {
            var type = typeof(T);
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (IsPropertyTypeValid(prop, out _) == false)
                    continue;

                var value = prop.GetValue(data);
                if (value != null)
                {
                    var valueString = value.ToString();

                    PlayerPrefs.SetString(GetPrefsKey(path, prop.Name), valueString);
                }
            }

            PlayerPrefs.Save();
        }

        public static T Load<T>(string path) where T : class, new()
        {
            var result = new T();

            var type = typeof(T);
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (IsPropertyTypeValid(prop, out TypeCode valueTypeCode) == false)
                    continue;

                var key = GetPrefsKey(path, prop.Name);
                if (PlayerPrefs.HasKey(key) == true)
                {
                    var value = PlayerPrefs.GetString(key);
                    object newValue = value;

                    switch (valueTypeCode)
                    {
                        case TypeCode.String:
                            break;
                        case TypeCode.Single:
                            float.TryParse(value, out float valueFloat);
                            newValue = valueFloat;
                            break;
                        case TypeCode.Int32:
                            int.TryParse(value, out int valueInt);
                            newValue = valueInt;
                            break;
                        default:
                            Debug.LogError($"[Storage] Add {valueTypeCode.ToString("G")} type to switch.");
                            continue;
                    }

                    prop.SetValue(result, newValue);
                }
            }

            return result;
        }

        private static bool IsPropertyTypeValid(PropertyInfo value, out TypeCode valueTypeCode)
        {
            valueTypeCode = Type.GetTypeCode(value.PropertyType);

            if (valueTypeCode == TypeCode.Int32 ||
                valueTypeCode == TypeCode.Single ||
                valueTypeCode == TypeCode.String)
                return true;

            return false;
        }
    }
}