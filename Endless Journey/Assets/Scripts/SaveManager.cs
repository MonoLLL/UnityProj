using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]
public class SaveManager: MonoBehaviour
{
    string filePath;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/savedgame.save";
    }
    public static void Save<T>(string key, T saveData)
    {
        string jsonData = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(key, jsonData);
    }
    public static T Load<T>(string key) where T: new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(loadedString);
        }
        else
            return new T();
    }
}
[System.Serializable]
public class Save
{

}
