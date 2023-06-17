using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Preload")
            SceneManager.LoadScene(1);
    }
}
