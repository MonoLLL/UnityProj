using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                    Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
