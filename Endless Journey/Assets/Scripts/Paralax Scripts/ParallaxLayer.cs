using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;


    //если parallaxFactor равен 1, то слой будет двигаться с той же скоростью, что и камера, если 0.5, то он будет двигаться в 2 раза медленнее, 2 - в 2 раза быстрее
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        transform.localPosition = newPos;
    }
}
