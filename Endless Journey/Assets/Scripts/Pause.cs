using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Image pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void PauseGame()
    {
        if (pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
