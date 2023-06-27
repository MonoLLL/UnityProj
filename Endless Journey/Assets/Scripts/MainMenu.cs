using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        Button[] btns = FindObjectsOfType<Button>();
        foreach (Button button in btns)
        {
            if (button.name != "CloseTab")
                button.interactable = false;
        }
    }
    public void SaveSettings()
    {
        AudioController.Controller.SaveSettings();
    }
    public void CloseTab()
    {
        Button[] btns = FindObjectsOfType<Button>();
        foreach (Button button in btns)
        {
            if (button.name != "CloseTab")
                button.interactable = true;
        }
    }
}
