using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int lvlUnlock { get; set; }
    public static float[] res { get; set; }
    public Button[] buttons;
    public Sprite lockedSprite;
    public Sprite[] unlockedSprites;
    public Image currentLvl;
    public Text currentLvlNum;
    public Image[] stars;
    public Image[] emptyStars;
    void Awake()
    {
        lvlUnlock = 1;
    }
    void Start()
    {
        SaveManager.manager.LoadGameProgress();
        // ƒл€ всех доступных уровней
        for (int i = 0; i < lvlUnlock; i++)
        {
            // ”становить состо€ние кнопки
            buttons[i].interactable = true;
            buttons[i].image.sprite = unlockedSprites[i];
            // јктивировать метку под текущим уровнем, помен€ть текст текущего уровн€
            if (i == lvlUnlock - 1)
            {
                currentLvl.gameObject.SetActive(true);
                currentLvl.transform.position = new Vector2(buttons[i].transform.position.x, buttons[i].transform.position.y-60);
                currentLvlNum.text = (i+1).ToString();
            }
            // Ўкала рейтинга устанавливаетс€ под всеми уровн€ми, кроме еще не пройденного последнего открытого
            else
            {
                float x, y;
                y = buttons[i].transform.position.y - 60;
                if (res[i] > 0)
                {
                    stars[i].gameObject.SetActive(true);
                    stars[i].fillAmount = res[i];
                    if (res[i] == 0.33)
                        x = buttons[i].transform.position.x + 20;
                    else if (res[i] == 0.66)
                        x = buttons[i].transform.position.x + 10;
                    else
                        x = buttons[i].transform.position.x;
                    stars[i].transform.position = new Vector2(x, y);
                }
                // ≈сли не было собрано ни одной звезды, устанавливаетс€ пуста€ шкала
                else
                {
                    emptyStars[i].gameObject.SetActive(true);
                    x = buttons[i].transform.position.x;
                    emptyStars[i].transform.position = new Vector2(x, y);
                }
            }
        }
        // ƒл€ всех недоступных уровней устанавливаетс€ неактивное состо€ние
        for (int i = lvlUnlock; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].image.sprite = lockedSprite;
        }
    }
    // «апустить текущий уровень по нажатию Enter
    void Update()
    {
        if (Input.GetKeyDown("return"))
            buttons[lvlUnlock - 1].onClick.Invoke();
    }
}
