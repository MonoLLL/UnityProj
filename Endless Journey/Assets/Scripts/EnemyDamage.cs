using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartCoroutine(ToDamage(collision));
    }
    private IEnumerator ToDamage(Collision2D collision)
    {
        while (collision.gameObject.GetComponent<Health>().currentHealth > 0)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
