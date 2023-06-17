using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int lvlUnlock;
    public Button[] buttons;
    public Sprite lockedSprite;
    public Sprite[] unlockedSprites;
    void Start()
    {
        lvlUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].image.sprite = lockedSprite;
        }
        for (int i = 0; i < lvlUnlock; i++)
        {
            buttons[i].interactable = true;
            buttons[i].image.sprite = unlockedSprites[i];
        }
    }
    public void Loadlevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex+1);
    }
}
