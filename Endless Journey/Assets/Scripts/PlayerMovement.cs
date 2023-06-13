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
    private BoxCollider2D collider;
    private enum MovementState { idle, running, jumping, attack }

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

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            body.AddForce(new Vector2(body.velocity.x, jump));
        if (Input.GetMouseButtonDown(0))
        {
            collider = GetComponent<BoxCollider2D>();
            StartCoroutine(UpdateCollider());
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (coordX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (coordX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (isJumping)
        {
            state = MovementState.jumping;
        }

        if (Input.GetMouseButtonDown(0))
        {
            state = MovementState.attack;
        }

        anim.SetInteger("state", (int)state);
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
    private IEnumerator UpdateCollider()
    {
        float size = collider.size.x;
        float offset = collider.offset.x;
        collider.size = new Vector2(3.5f, collider.size.y);
        collider.offset = new Vector2(0.8f, collider.offset.y);
        yield return new WaitForSeconds(1);
        collider.size = new Vector2(size, collider.size.y);
        collider.offset = new Vector2(offset, collider.offset.y);
    }
}
