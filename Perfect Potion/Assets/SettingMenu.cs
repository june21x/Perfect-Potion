using UnityEngine.UI;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    /* private static readonly string bgmPref = "bgmPref";
    private static readonly string soundPref = "soundPref";
    private float bgmFloat, soundFloat;
    public AudioSource bgmAudio;
    public AudioSource[] soundAudio;

    void Awake()
    {
        MusicAndSoundSetting();
    }

    private void MusicAndSoundSetting()
    {
        bgmFloat = PlayerPrefs.GetFloat(bgmPref);
        soundFloat = PlayerPrefs.GetFloat(soundPref);

        bgmAudio.volume = bgmFloat;

        for (int i = 0; i < soundAudio.Length; i++)
        {
            soundAudio[i].volume = soundFloat;
        }
    } */

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitSetting(GameObject settingObject)
    {
        settingObject.SetActive(!settingObject.activeSelf);
    }
}
