using System.Collections;
using System.Collections.Generic;
using System.Timers;
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
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PatrolScript>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Invoke(nameof(Death), 0.7f);
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
