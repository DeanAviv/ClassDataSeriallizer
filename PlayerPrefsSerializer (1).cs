using UnityEngine;

namespace Utility
{
  /// <summary>A generic solution for saving and loading different game data into PlayerPrefs</summary>
  public static class PlayerPrefsSerializer
  {
    public static void Save<T>(T data, string key)
    {
      string json = JsonUtility.ToJson(data);
      PlayerPrefs.SetString(key, json);
      PlayerPrefs.Save();
    }

    public static T Load<T>(string key)
    {
      if (PlayerPrefs.HasKey(key))
      {
        string json = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<T>(json);
      }
      else 
      {
        Debug.LogWarning($"Could not find data for key: {key}");
        return default;
      }
    }
  }
}
