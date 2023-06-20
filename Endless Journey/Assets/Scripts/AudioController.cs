using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    // Свойство для доступа к членам класса из других классов
    public static AudioController Controller {get; private set;}
    // Слайдеры - ползунки
    public Slider slider;
    public Slider slider2;
    // Изображения для концов ползунка
    public Sprite audioOn;
    public Sprite audioOff;
    public Sprite soundOn;
    public Sprite soundOff;
    // Конец ползунка
    private GameObject handle;
    private GameObject handle2;
    // Источники звука
    private AudioSource[] sources; 
    private AudioSource audioSource;
    private AudioSource audioSource2;
    public void Awake()
    {
        // Инициализация
        handle = GameObject.FindGameObjectWithTag("Handle");
        handle2 = GameObject.FindGameObjectWithTag("Handle2");
        sources = FindObjectsOfType<AudioSource>();
        audioSource2 = sources[1];
        audioSource = sources[0];
    }
    public void Update()
    {
        // Управление звуками
        audioSource.volume = slider.value;

        audioSource2.volume = slider2.value;
        SoundManager.currentVolume = slider2.value;

        OnOffAudio();
    }
    public void OnOffAudio()
    {
        // Смена изображений
        if (slider.value > 0)
            handle.GetComponent<Image>().sprite = audioOn;
        else
            handle.GetComponent<Image>().sprite = audioOff;

        if (slider2.value > 0)
            handle2.GetComponent<Image>().sprite = soundOn;
        else
            handle2.GetComponent<Image>().sprite = soundOff;
    }
    // Сохранение настроек
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("music", slider.value);
        PlayerPrefs.SetFloat("sound", slider2.value);
    }
    // Восстановление настроек
    public void LoadSettings()
    {
        PlayerPrefs.GetFloat("music", slider.value);
        PlayerPrefs.GetFloat("sound", slider2.value);
    }
}
