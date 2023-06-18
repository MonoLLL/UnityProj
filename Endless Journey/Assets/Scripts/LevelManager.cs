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
    public Image currentLvl;
    public Text currentLvlNum;

    void Update()
    {
        if (Input.GetKeyDown("return"))
            buttons[lvlUnlock - 1].onClick.Invoke();
    }
    void Start()
    {
        lvlUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < lvlUnlock; i++)
        {
            buttons[i].interactable = true;
            buttons[i].image.sprite = unlockedSprites[i];
            if (i == lvlUnlock - 1)
            {
                currentLvl.gameObject.SetActive(true);
                currentLvl.transform.position = new Vector2(buttons[i].transform.position.x, buttons[i].transform.position.y-60);
                currentLvlNum.text = (i+1).ToString();
            }
        }
        for (int i = lvlUnlock; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].image.sprite = lockedSprite;
        }
        buttons[1].interactable = true;
        buttons[2].interactable = true;
        buttons[3].interactable = true;
    }
    public void Loadlevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex+1);
    }
}
