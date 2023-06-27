using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Свойство для доступа к членам класса из других классов
    public static SoundManager instance { get; private set; }
    public static float currentVolume;
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
    public void PlaySound(AudioClip _sound)
    {
        // Метод проигрывает звук один раз
        source.PlayOneShot(_sound, currentVolume);
    }
}
