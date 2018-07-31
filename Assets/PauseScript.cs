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
    [SerializeField] private SceneManager sceneManager;

    private void Start()
    {
        audioMixer.GetFloat("MasterVolume", out outMasterVolume);
        masterSlider.value = AudioManager.Instance.dBToVolume(outMasterVolume);
        audioMixer.GetFloat("MusicVolume", out outMusicVolume);
        musicSlider.value = AudioManager.Instance.dBToVolume(outMusicVolume);
        audioMixer.GetFloat("EffectVolume", out outEffectVolume);
        effectSlider.value = AudioManager.Instance.dBToVolume(outEffectVolume);
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
        //! PLayer loop to set all the sort layers
        for(int i=0;i<sceneManager.playerList.Count;i++)
        {
            sceneManager.playerList[i].transform.GetChild(2).GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
            sceneManager.GetComponent<SceneManager>().playerList[i].transform.GetChild(2).GetChild(2).GetComponent<Canvas>().sortingOrder = 0;
            sceneManager.GetComponent<SceneManager>().playerList[i].transform.GetChild(2).GetChild(3).GetComponent<Canvas>().sortingOrder = 0;
            sceneManager.GetComponent<SceneManager>().playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 0;

            sceneManager.playerList[i].GetComponent<actionTimeBar>().startSelection = 0;
        }
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    public void ClickSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("MenuClickSound");
    }

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


