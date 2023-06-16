using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health: MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private AudioClip hurtSound;
    public GameObject deathWindow;
    private GameObject player;
    private GameObject[] enemies;
    public float currentHealth { get; private set; }
    private Animator anim;
    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if(currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtSound, SoundManager.currentVolume);
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("hurt");    //Здесь должна быть анимация смерти
            deathWindow.SetActive(true);
            player = GameObject.FindGameObjectWithTag("Player");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Destroy(player);
            foreach (GameObject enemy in enemies)
                Destroy(enemy);
        }
    }
}
