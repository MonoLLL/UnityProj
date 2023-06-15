using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public static float currentVolume;
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

        //if (instance == null)
        //{
        //    instance = this;
            DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != null && instance != this)
        //    Destroy(gameObject);
    }
    public void PlaySound(AudioClip _sound, float volume)
    {
        source.PlayOneShot(_sound, volume);
    }
}
