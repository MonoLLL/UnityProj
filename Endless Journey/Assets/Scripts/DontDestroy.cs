using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    private DontDestroy[] reloadedObjs;
    public void Start()
    {
        reloadedObjs = FindObjectsOfType<DontDestroy>(true);
        for (int i = 0; i < reloadedObjs.Length; i++)
        {
            if (reloadedObjs[i] != this && reloadedObjs[i].name == gameObject.name)
            {
                if (reloadedObjs[i].CompareTag("Options"))
                    Destroy(reloadedObjs[i]);
                else
                    Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
