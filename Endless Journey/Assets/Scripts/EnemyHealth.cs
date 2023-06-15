using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private AudioClip deathSound;
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
        if (currentHealth <= 0)
        {
            SoundManager.instance.PlaySound(deathSound,  SoundManager.currentVolume);
            anim.SetTrigger("death");    //Здесь должна быть анимация смерти
            //GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
