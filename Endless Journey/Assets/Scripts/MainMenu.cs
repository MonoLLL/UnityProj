using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int index)
    {
        StartCoroutine(OnButtonClicked(index));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void FindLoadedObjects()
    {
        for (int i = 0; i < FindObjectsOfType<DontDestroy>(true).Length; i++)
        {
            if (FindObjectsOfType<DontDestroy>(true)[i].name == "SettingsCanvas")
                FindObjectsOfType<DontDestroy>(true)[i].gameObject.SetActive(true);
        }
    }
    public IEnumerator OnButtonClicked(int index)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
    }
    public void Help()
    {
        string commandText = @"help.chm";
	    var proc = new System.Diagnostics.Process();
 	    proc.StartInfo.FileName = commandText;
 	    proc.StartInfo.UseShellExecute = true;
 	    proc.Start ();
    }
}
