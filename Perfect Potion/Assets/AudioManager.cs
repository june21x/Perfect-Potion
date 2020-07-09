using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgmPref = "bgmPref";
    private static readonly string soundPref = "soundPref";
    private int firstPlayInt;
    public Slider bgmSlider, soundSlider;
    private float bgmFloat, soundFloat;
    public AudioSource bgmAudio;
    public AudioSource[] soundAudio;

    //public static AudioManager instance;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            bgmFloat = .50f;
            soundFloat = 1f;
            bgmSlider.value = bgmFloat;
            soundSlider.value = soundFloat;
            PlayerPrefs.SetFloat(bgmPref, bgmFloat);
            PlayerPrefs.SetFloat(soundPref, soundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            bgmFloat = PlayerPrefs.GetFloat(bgmPref);
            bgmSlider.value = bgmFloat;
            soundFloat = PlayerPrefs.GetFloat(soundPref);
            soundSlider.value = soundFloat;
        }
    }

    /* void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    } */

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(bgmPref, bgmSlider.value);
        PlayerPrefs.SetFloat(soundPref, soundSlider.value);
    }

    void OnAppFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateVolume()
    {
        bgmAudio.volume = bgmSlider.value;

        for (int i = 0; i < soundAudio.Length; i++)
        {
            soundAudio[i].volume = soundSlider.value;
        }
    }
}
