using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRise : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D collision;
    private Animator anim;
    private bool playerNear = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Static;
        anim = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
        collision.isTrigger = true;
        collision.size = new Vector2(25, 5);
        collision.offset = new Vector2(0, 1);
    }

    void Update()
    {
        if (playerNear)
        {
            anim.SetBool("rise", true);
            collision.size = new Vector2(1.5f, 2.5f);
            collision.offset = new Vector2(0, -0.25f);
            Invoke(nameof(ChangeScript), 0.6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            playerNear = true;
    }

    void ChangeScript()
    {
        collision.isTrigger = false;
        body.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<PatrolScript>().enabled = true;
        GetComponent<SkeletonRise>().enabled = false;
    }
}
