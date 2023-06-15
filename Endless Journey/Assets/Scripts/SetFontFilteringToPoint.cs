using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFontFilteringToPoint : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
    }
}
