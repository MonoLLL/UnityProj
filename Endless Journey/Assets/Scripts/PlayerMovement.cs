using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D body;

    private float coordX = 0f;
    public bool isJumping;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        coordX = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(coordX*speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            body.AddForce(new Vector2(body.velocity.x, jump));

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (coordX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (coordX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
