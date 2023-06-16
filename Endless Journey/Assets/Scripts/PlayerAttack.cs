using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage = 1;
    public float cooldown = 0.28f;
    private float canAttack;
    [SerializeField] private AudioClip attackSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GetComponent<PlayerMovement>().isJumping && Time.time > canAttack)
        {
            Attack();
            canAttack = Time.time + cooldown;
        }
    }
    private void Attack()
    {
        ToggleMovement();
        SoundManager.instance.PlaySound(attackSound, SoundManager.currentVolume);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Invoke(nameof(ToggleMovement), cooldown);
    }
    private void ToggleMovement()
    {
        GetComponent<PlayerMovement>().canMove = !GetComponent<PlayerMovement>().canMove;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
