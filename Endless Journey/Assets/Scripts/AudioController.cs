using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    public Sprite audioOn;
    public Sprite audioOff;
    public Sprite soundOn;
    public Sprite soundOff;
    private GameObject handle;
    private GameObject handle2;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public void Awake()
    {
        handle = GameObject.FindGameObjectWithTag("Handle");
        handle2 = GameObject.FindGameObjectWithTag("Handle2");
    }
    public void Update()
    {
        audioSource.volume = slider.value;

        audioSource2.volume = slider2.value;
        SoundManager.currentVolume = slider2.value;

        OnOffAudio();
    }
    public void OnOffAudio()
    {
        if (slider.value > 0)
            handle.GetComponent<Image>().sprite = audioOn;
        else
            handle.GetComponent<Image>().sprite = audioOff;

        if (slider2.value > 0)
            handle2.GetComponent<Image>().sprite = soundOn;
        else
            handle2.GetComponent<Image>().sprite = soundOff;
    }
}
