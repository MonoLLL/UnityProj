using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] public bool canMove;
    [SerializeField] private LayerMask layer;
    private Animator anim;
    public SpriteRenderer sprite;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private enum MovementState { idle, running, jumping, attack }

    private float coordX = 0f;
    public bool isJumping;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        canMove = true;
    }
    private void Update()
    {
        if (canMove)
        {
            coordX = Input.GetAxisRaw("Horizontal");

            body.velocity = new Vector2(coordX * speed, body.velocity.y);

            isJumping = !IsOnGround();

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                body.AddForce(new Vector2(body.velocity.x, jump));
                SoundManager.instance.PlaySound(jumpSound);
            }
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

    private bool IsOnGround()
    {
        RaycastHit2D onGround = Physics2D.BoxCast(boxCollider.bounds.min + new Vector3(boxCollider.bounds.extents.x, 0), new Vector2(boxCollider.bounds.size.x - 0.2f, 0.2f), 0f, Vector2.down, 0.2f, layer);
        return onGround.collider != null;
    }
}
