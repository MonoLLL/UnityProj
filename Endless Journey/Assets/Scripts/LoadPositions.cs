using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPositions : MonoBehaviour
{
    public void LoadData(Save.SaveData save)
    {
        transform.position = new Vector2(save.position.x, save.position.y);
    }
}
