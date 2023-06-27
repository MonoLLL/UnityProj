using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �������� ��� ������� � ������ ������ �� ������ �������
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
        // ����� ����������� ���� ���� ���
        source.PlayOneShot(_sound, currentVolume);
    }
}
