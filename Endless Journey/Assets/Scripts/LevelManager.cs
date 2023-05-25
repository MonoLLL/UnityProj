using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int lvlUnlock;
    public Button[] buttons;
    public void LoadLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        lvlUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < lvlUnlock; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void Loadlevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex+1);
    }
}
