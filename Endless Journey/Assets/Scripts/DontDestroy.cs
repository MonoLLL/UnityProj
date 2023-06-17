using System;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    public void Awake()
    {
        if (FindObjectOfType<DontDestroy>() != this)
        {
            if (FindObjectOfType<DontDestroy>().name == this.name)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
