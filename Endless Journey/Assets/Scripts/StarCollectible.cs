using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollectible : MonoBehaviour
{
    [SerializeField] private Image totalBar;
    [SerializeField] private AudioClip plusStarSound;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            totalBar.fillAmount += 0.33f;
            SoundManager.instance.PlaySound(plusStarSound, SoundManager.currentVolume);
            gameObject.SetActive(false);
        }
    }
}
