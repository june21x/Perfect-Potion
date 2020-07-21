using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Settings : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string prefBGMVolume = "prefBGMVolume";
    private static readonly string prefIsBGMMute = "prefIsBGMMute";
    private static readonly string prefSoundVolume = "prefSoundVolume";
    private static readonly string prefIsSoundMute = "prefIsSoundMute";
    private static readonly string prefIsFullscreen = "prefIsFullScreen";
    private static readonly string mixerBGMVolume = "BGM Volume";
    private static readonly string mixerSoundVolume = "Sound Volume";
    private int firstPlayInt;
    public Slider bgmSlider, soundSlider;
    private float bgmVolume, soundVolume;
    private int isBGMMute, isSoundMute;
    private int isFullscreen;
    public AudioSource bgmAudio;
    public AudioSource[] soundAudio;
    public AudioMixer audioMixer;
    public Toggle bgmMuteToggle;
    public Toggle soundMuteToggle;
    public Toggle fullscreenToggle;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) //First Play
        {
            bgmVolume = 0;
            isBGMMute = 0;
            soundVolume = 0;
            isSoundMute = 0;
            isFullscreen = 1;

            audioMixer.SetFloat(mixerBGMVolume, bgmVolume);
            audioMixer.SetFloat(mixerSoundVolume, soundVolume);

            bgmSlider.value = Mathf.Pow(10, bgmVolume / 10);
            soundSlider.value = Mathf.Pow(10, soundVolume / 10);

            bgmMuteToggle.isOn = false;
            soundMuteToggle.isOn = false;

            fullscreenToggle.isOn = true;

            //Save Default Settings in Player Preferences

            PlayerPrefs.SetFloat(prefBGMVolume, bgmVolume);
            PlayerPrefs.SetInt(prefIsBGMMute, isBGMMute);

            PlayerPrefs.SetFloat(prefSoundVolume, soundVolume);
            PlayerPrefs.SetInt(prefIsSoundMute, isSoundMute);

            PlayerPrefs.SetInt(prefIsFullscreen, isFullscreen);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            //Load Settings from Player Preferences

            bgmVolume = PlayerPrefs.GetFloat(prefBGMVolume);
            soundVolume = PlayerPrefs.GetFloat(prefSoundVolume);
            bgmSlider.value = Mathf.Pow(10, bgmVolume / 10);
            soundSlider.value = Mathf.Pow(10, soundVolume / 10);

            if (PlayerPrefs.GetInt(prefIsBGMMute) == 1)
            {
                audioMixer.SetFloat(mixerBGMVolume, -80f);
                bgmMuteToggle.isOn = true;
                bgmSlider.enabled = false;
            } else
            {
                audioMixer.SetFloat(mixerBGMVolume, bgmVolume);
                bgmMuteToggle.isOn = false;
                bgmSlider.enabled = true;
            }

            if (PlayerPrefs.GetInt(prefIsSoundMute) == 1)
            {
                audioMixer.SetFloat(mixerSoundVolume, -80f);
                soundMuteToggle.isOn = true;
                soundSlider.enabled = false;
            } else
            {
                audioMixer.SetFloat(mixerSoundVolume, soundVolume);
                soundMuteToggle.isOn = false;
                soundSlider.enabled = true;
            }

            if (PlayerPrefs.GetInt(prefIsFullscreen) == 1)
            {
                Screen.fullScreen = true;
                fullscreenToggle.isOn = true;
            } else
            {
                Screen.fullScreen = false;
                fullscreenToggle.isOn = false;
            }
        }

    }

    public void SetBGMVolume(float sliderValue)
    {
        audioMixer.SetFloat(mixerBGMVolume, Mathf.Log10(sliderValue) * 10);
        PlayerPrefs.SetFloat(prefBGMVolume, Mathf.Log10(sliderValue) * 10);
    }
    public void SetSoundVolume(float sliderValue)
    {
        audioMixer.SetFloat(mixerSoundVolume, Mathf.Log10(sliderValue) * 10);
        PlayerPrefs.SetFloat(prefSoundVolume, Mathf.Log10(sliderValue) * 10);
    }

    public void MuteBGMVolume(bool isMute)
    {
        if (isMute == true)
        {
            audioMixer.SetFloat(mixerBGMVolume, -80f);
            PlayerPrefs.SetInt(prefIsBGMMute, 1);
            bgmSlider.enabled = false;
        } else
        {
            audioMixer.SetFloat(mixerBGMVolume, PlayerPrefs.GetFloat(prefBGMVolume));
            PlayerPrefs.SetInt(prefIsBGMMute, 0);
            bgmSlider.enabled = true;
        }

        Debug.Log("BGM Volume in PlayerPref = " + PlayerPrefs.GetFloat(prefBGMVolume));

    }

    public void MuteSoundVolume(bool isMute)
    {
        if (isMute == true)
        {
            audioMixer.SetFloat(mixerSoundVolume, -80f);
            PlayerPrefs.SetInt(prefIsSoundMute, 1);
            soundSlider.enabled = false;
        }
        else
        {
            audioMixer.SetFloat(mixerSoundVolume, PlayerPrefs.GetFloat(prefSoundVolume));
            PlayerPrefs.SetInt(prefIsSoundMute, 0);
            soundSlider.enabled = true;
        }

    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen == true)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt(prefIsFullscreen, 1);
        } else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt(prefIsFullscreen, 0);
        }

    }

    //OLD CODES (By Jia Phei)--------------------------------------------------------

    //public void SaveSoundSettings()
    //{
    //    PlayerPrefs.SetFloat(prefBGMVolume, bgmSlider.value);
    //    PlayerPrefs.SetFloat(prefSoundVolume, soundSlider.value);
    //}

    //void OnAppFocus(bool inFocus)
    //{
    //    if (!inFocus)
    //    {
    //        SaveSoundSettings();
    //    }
    //}

    //public void UpdateVolume()
    //{
    //    musicAudio.volume = bgmSlider.value;

    //    for (int i = 0; i < soundAudio.Length; i++)
    //    {
    //        soundAudio[i].volume = soundSlider.value;
    //    }

    //    SaveSoundSettings();
    //}
}
