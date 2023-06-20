using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    // �������� ��� ������� � ������ ������ �� ������ �������
    public static AudioController Controller {get; private set;}
    // �������� - ��������
    public Slider slider;
    public Slider slider2;
    // ����������� ��� ������ ��������
    public Sprite audioOn;
    public Sprite audioOff;
    public Sprite soundOn;
    public Sprite soundOff;
    // ����� ��������
    private GameObject handle;
    private GameObject handle2;
    // ��������� �����
    private AudioSource[] sources; 
    private AudioSource audioSource;
    private AudioSource audioSource2;
    public void Awake()
    {
        // �������������
        handle = GameObject.FindGameObjectWithTag("Handle");
        handle2 = GameObject.FindGameObjectWithTag("Handle2");
        sources = FindObjectsOfType<AudioSource>();
        audioSource2 = sources[1];
        audioSource = sources[0];
    }
    public void Update()
    {
        // ���������� �������
        audioSource.volume = slider.value;

        audioSource2.volume = slider2.value;
        SoundManager.currentVolume = slider2.value;

        OnOffAudio();
    }
    public void OnOffAudio()
    {
        // ����� �����������
        if (slider.value > 0)
            handle.GetComponent<Image>().sprite = audioOn;
        else
            handle.GetComponent<Image>().sprite = audioOff;

        if (slider2.value > 0)
            handle2.GetComponent<Image>().sprite = soundOn;
        else
            handle2.GetComponent<Image>().sprite = soundOff;
    }
    // ���������� ��������
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("music", slider.value);
        PlayerPrefs.SetFloat("sound", slider2.value);
    }
    // �������������� ��������
    public void LoadSettings()
    {
        PlayerPrefs.GetFloat("music", slider.value);
        PlayerPrefs.GetFloat("sound", slider2.value);
    }
}
