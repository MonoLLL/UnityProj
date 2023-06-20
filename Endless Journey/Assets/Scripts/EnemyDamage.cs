using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage;
    private static float health;
    private static GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            health = player.GetComponent<Health>().currentHealth;
            StartCoroutine(ToDamage());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StopAllCoroutines();
    }
    private IEnumerator ToDamage()
    {
        while (health > 0)
        {
            player.GetComponent<Health>().TakeDamage(damage);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
