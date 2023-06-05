using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentPoint = rightPoint.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == rightPoint.transform)
        {
            body.velocity = new Vector2(speed, 0);
            sprite.flipX = true;
        }
        else
        {
            body.velocity = new Vector2(-speed, 0);
            sprite.flipX = false;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) <  1f && currentPoint == rightPoint.transform)
        {
            currentPoint = leftPoint.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == leftPoint.transform)
        {
            currentPoint = rightPoint.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(leftPoint.transform.position, 1f);
        Gizmos.DrawWireSphere(rightPoint.transform.position, 1f);
        Gizmos.DrawLine(leftPoint.transform.position, rightPoint.transform.position);
    }
}
