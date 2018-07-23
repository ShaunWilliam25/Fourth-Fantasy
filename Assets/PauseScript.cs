using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectSlider;
    public float outMasterVolume;
    public float outMusicVolume;
    public float outEffectVolume;

    private void Start()
    {
        audioMixer.GetFloat("MasterVolume", out outMasterVolume);
        masterSlider.value = outMasterVolume;
        audioMixer.GetFloat("MusicVolume", out outMusicVolume);
        musicSlider.value = outMusicVolume;
        audioMixer.GetFloat("EffectVolume", out outEffectVolume);
        effectSlider.value = outEffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Pause Menu");
            }
            else
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }    
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToTitle()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }
    public void SkipTut()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    public void ClickSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("MenuClickSound");
    }

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void setEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }


    /*
     * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipTutScript : MonoBehaviour
{
    public Canvas SkipTutorial;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!SkipTutorial.gameObject.activeInHierarchy)
            {
                SkipTutorial.gameObject.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Skip tut");
            }
            else
            {
                SkipTutorial.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

       }*/
}


