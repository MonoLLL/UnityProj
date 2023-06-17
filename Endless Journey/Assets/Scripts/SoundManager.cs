using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public static float currentVolume = 1f;
    private AudioSource source;
    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
        source = GetComponent<AudioSource>();
    }
    public void Init()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound, float volume)
    {
        Init();
        source.PlayOneShot(_sound, volume);
    }
}
