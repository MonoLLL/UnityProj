using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAttackPoint : MonoBehaviour
{
    private PlayerMovement player;
    private Transform attackPoint;

    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
        attackPoint = GetComponent<Transform>();
    }

    void Update()
    {
        if (!player.sprite.flipX)
        {
            attackPoint.localPosition = new Vector3(2.5f, -1);
        }
        else
        {
            attackPoint.localPosition = new Vector3(-2.5f, -1);
        }
    }
}
