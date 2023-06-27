using UnityEngine;

public class SettingsReload : MonoBehaviour
{
    public string name;
    void Awake()
    {
        AudioSource source = FindObjectOfType<AudioSource>();
        source.volume = PlayerPrefs.GetFloat(name);
        if (name == "sound")
            SoundManager.currentVolume = PlayerPrefs.GetFloat(name);
    }
}
