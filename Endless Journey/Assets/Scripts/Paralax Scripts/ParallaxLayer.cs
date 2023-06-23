using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;


    //���� parallaxFactor ����� 1, �� ���� ����� ��������� � ��� �� ���������, ��� � ������, ���� 0.5, �� �� ����� ��������� � 2 ���� ���������, 2 - � 2 ���� �������
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        transform.localPosition = newPos;
    }
}
