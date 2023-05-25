using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Help()
    {
        string commandText = @"C:\Users\Acer\Documents\GitHub\UnityProj\Endless Journey\help.chm";

	    var proc = new System.Diagnostics.Process();
 	    proc.StartInfo.FileName = commandText;
 	    proc.StartInfo.UseShellExecute = true;
 	    proc.Start ();
    }
}
