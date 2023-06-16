using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public GameObject bottomPoint;
    public GameObject topPoint;
    private Rigidbody2D body;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentPoint = topPoint.transform;
    }

    void Update()
    {
        if (currentPoint == topPoint.transform)
        {
            body.velocity = new Vector2(0, speed);
        }
        else
        {
            body.velocity = new Vector2(0, -speed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == bottomPoint.transform)
        {
            currentPoint = topPoint.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == topPoint.transform)
        {
            currentPoint = bottomPoint.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(topPoint.transform.position, 1f);
        Gizmos.DrawWireSphere(bottomPoint.transform.position, 1f);
        Gizmos.DrawLine(topPoint.transform.position, bottomPoint.transform.position);
    }
}
