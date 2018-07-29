using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle fullscreen;
    public EventSystem eventSystem;
    public Button newGame;
    public Button backToMainMenu;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectSlider;
    public float outMasterVolume;
    public float outMusicVolume;
    public float outEffectVolume;

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", AudioManager.Instance.VolumeTodB(volume));
    }
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", AudioManager.Instance.VolumeTodB(volume));
    }
    public void setEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", AudioManager.Instance.VolumeTodB(volume));
    }
    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if(!isFullscreen)
        {
            Screen.SetResolution(1280, 720, false);
        }
    }

    public void BackToMainMenu()
    {
        eventSystem.SetSelectedGameObject(newGame.gameObject);
    }

    public void Awake()
    {
        fullscreen.isOn = Screen.fullScreen;
        audioMixer.SetFloat("MasterVolume", -5f);
        audioMixer.SetFloat("MusicVolume", -5f);
        audioMixer.SetFloat("EffectVolume", -5f);
        audioMixer.GetFloat("MasterVolume", out outMasterVolume);
        masterSlider.value = AudioManager.Instance.dBToVolume(outMasterVolume);
        Debug.Log(AudioManager.Instance.dBToVolume(outMasterVolume));
        audioMixer.GetFloat("MusicVolume", out outMusicVolume);
        musicSlider.value = AudioManager.Instance.dBToVolume(outMusicVolume);
        audioMixer.GetFloat("EffectVolume", out outEffectVolume);
        effectSlider.value = AudioManager.Instance.dBToVolume(outEffectVolume);
    }

    private void Update()
    {
        if(backToMainMenu.gameObject.activeInHierarchy)
        {
            eventSystem.SetSelectedGameObject(backToMainMenu.gameObject);
        }
    }

}
