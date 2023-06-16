using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public AudioClip clickSnd;

    public void SoundClick()
    {
        SoundManager.instance.PlaySound(clickSnd, SoundManager.currentVolume);
    }
    public void SoundOpenMenu()
    {
        SoundManager.instance.PlaySound(clickSnd, SoundManager.currentVolume);
    }
    public void FixAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.CrossFade("Normal", 0f);
        animator.Update(0f);
    }
}
