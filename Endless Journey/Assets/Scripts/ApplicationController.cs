using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationController: MonoBehaviour
{
    //private void OnSceneUnloaded(Scene current)
    //{
    //    if (current.buildIndex < 2)
    //        SaveManager.manager.SaveInProcess();
    //}
    //private void OnSceneLoaded(Scene current, LoadSceneMode mode)
    //{
    //    if (current.buildIndex == LevelManager.lvlUnlock + 2)
    //        SaveManager.manager.LoadGameProcess();
    //}
    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //    //SceneManager.sceneUnloaded += OnSceneUnloaded;
    //}
    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //    //SceneManager.sceneUnloaded -= OnSceneUnloaded;
    //}
    public static void OnLoadLastLvl()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SaveManager.manager.LoadGameProgress();
        }
    }
    [RuntimeInitializeOnLoadMethod]
    public void OnApplicationOpen()
    {
        //AudioController.Controller.LoadSettings();
    }
    public void OnApplicationQuit()
    {
        //if (SceneManager.GetActiveScene().buildIndex == LevelManager.lvlUnlock + 2)
        //{
        //    SaveManager.manager.SaveInProcess();
        //}
        PlayerPrefs.Save();
    }
}
