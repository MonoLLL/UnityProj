using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationController: MonoBehaviour
{
    //private void Awake()
    //{
    //    if (gameObject == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        if (gameObject != this)
    //            Destroy(gameObject);
    //    }
    //}
    private void OnSceneUnloaded(Scene current)
    {
        if (current.buildIndex < 2)
            SaveManager.manager.SaveInProcess();
    }    
    private void OnSceneLoaded(Scene current, LoadSceneMode mode)
    {
        SaveManager.manager.LoadGameProcess();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public static void OnLoadLastLvl()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SaveManager.manager.LoadGameProgress();
        }
    }
    public void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex == LevelManager.lvlUnlock + 2)
        {
            SaveManager.manager.SaveInProcess();
        }
    }
}
