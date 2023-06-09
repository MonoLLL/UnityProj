using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollectible : MonoBehaviour
{
    public static StarCollectible Instance { get; private set; }
    public float Score;
    public Image totalBar;
    [SerializeField] private AudioClip plusStarSound;

    public void Awake()
    {
        Instance = this;
        Score = 0f;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            totalBar.fillAmount += 0.33f;
            SoundManager.instance.PlaySound(plusStarSound);
            gameObject.SetActive(false);
        }
        SaveScore();
    }
    public void SaveScore()
    {
        Score = totalBar.fillAmount;
    }
    public void LoadScore()
    {
        totalBar.fillAmount = Score;
    }
}
