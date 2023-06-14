using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage = 1;
    [SerializeField] private AudioClip attackSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            new WaitForSeconds(1);
            Attack();
        }
    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(attackSound);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
