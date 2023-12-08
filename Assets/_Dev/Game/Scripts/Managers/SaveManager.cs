using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Managers
{
    public class SaveManager : Singleton<SaveManager>
    {
        public static int LoadValue(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static void SaveValue(string key, int newAmount)
        {
            PlayerPrefs.SetInt(key, newAmount);
        }

        public static bool IsKeyExist(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}
