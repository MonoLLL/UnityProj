using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clickSnd;
    public void SoundClick()
    {
        SoundManager.instance.PlaySound(clickSnd);
    }
    public void PlayGame(int index)
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(OnButtonClicked(index));
    }
    public IEnumerator OnButtonClicked(int index)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void FindLoadedObjects()
    {
        DontDestroy settings = FindObjectOfType<DontDestroy>();
        settings.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void SaveSettings()
    {
        AudioController.Controller.SaveSettings();
    }
    public void CloseTabOnMenu()
    {
        FindDeactivatedObjects(2, 2);
    }
    public void FindDeactivatedObjects(int rootToActive, int childToActive)
    {
        GameObject[] objs = SceneManager.GetActiveScene().GetRootGameObjects();
        objs[rootToActive].transform.GetChild(childToActive).gameObject.SetActive(true);
    }
}
