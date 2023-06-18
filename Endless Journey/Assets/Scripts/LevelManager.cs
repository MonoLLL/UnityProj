using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int lvlUnlock { get; set; }
    public Button[] buttons;
    public Sprite lockedSprite;
    public Sprite[] unlockedSprites;
    public Image currentLvl;
    public Text currentLvlNum;
    public Image stars;
    public Image emptyStars;
    private void Awake()
    {
        lvlUnlock = 1;
    }
    void Start()
    {
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
            else
            {
                float x, y;
                y = buttons[i].transform.position.y - 60;
                float res = StarCollectible.Instance.Score;
                if (res > 0)
                {
                    stars.gameObject.SetActive(true);
                    stars.fillAmount = StarCollectible.Instance.Score;
                    if (res == 0.33)
                        x = buttons[i].transform.position.x + 20;
                    else if (res == 0.66)
                        x = buttons[i].transform.position.x + 10;
                    else
                        x = buttons[i].transform.position.x;
                    stars.transform.position = new Vector2(x, y);
                }
                else
                {
                    emptyStars.gameObject.SetActive(true);
                    x = buttons[i].transform.position.x;
                    stars.transform.position = new Vector2(x, y);
                }
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
    void Update()
    {
        if (Input.GetKeyDown("return"))
            buttons[lvlUnlock - 1].onClick.Invoke();
    }
    public void Loadlevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex+1);
    }
}
