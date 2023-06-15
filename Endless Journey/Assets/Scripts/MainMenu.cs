using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(OnButtonClicked());
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public IEnumerator OnButtonClicked()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
