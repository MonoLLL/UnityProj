using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Input.GetMouseButtonDown(0))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
