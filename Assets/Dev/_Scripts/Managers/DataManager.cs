using System;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    #region PUBLIC METHODS

    public void Save<T>(string key, T value)
    {
        // If return type is a simple type like int, float or string
        // directly save it to PlayerPrefs
        if (typeof(T).IsValueType || value is string)
        {
            PlayerPrefs.SetString(key, value.ToString());
        }
        else
        {
            // Or use json for complex types
            string serializedValue = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, serializedValue);
        }

        PlayerPrefs.Save();
    }

    public T Load<T>(string key, T defaultValue = default)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string serializedValue = PlayerPrefs.GetString(key);

            // If return type is a simple type like int, float or string
            // directly convert string to return type
            if (typeof(T).IsValueType || defaultValue is string)
            {
                try
                {
                    return (T)Convert.ChangeType(serializedValue, typeof(T));
                }
                catch (FormatException)
                {
                    Debug.LogWarning("Failed to convert PlayerPrefs value to type: " + typeof(T));
                    return defaultValue;
                }
            }

            // Using json for complex types
            T value = JsonUtility.FromJson<T>(serializedValue);
            return value;
        }

        return defaultValue;
    }

    #endregion
}