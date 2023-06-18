using System;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    public void Awake()
    {
        DontDestroy[] saved = FindObjectsOfType<DontDestroy>(true);
        foreach (var item in saved)
        {
            if (item != this)
            {
                if (item.name == this.name)
                    Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
