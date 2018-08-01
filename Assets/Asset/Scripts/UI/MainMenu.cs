using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public int SceneIndex = 1;
    public EventSystem eventSystem;
    public Button backToMainMenu;
    public AudioManager audioManager;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); ///get the next level after pressting start
	}

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    /*public void Remapping()
    {
        Debug.Log("remapping controls");
    }*/
    public void Settings()
    {
        eventSystem.SetSelectedGameObject(backToMainMenu.gameObject);
    }

    private void Start()
    {
        if (audioManager.soundPlaying.Count > 0)
        {
            for (int i = 0; i < audioManager.soundPlaying.Count; i++)
            {
                audioManager.soundPlaying[i].source.Stop();
            }
            audioManager.soundPlaying.Clear();
        }                
        AudioManager.instance.PlaySound("MenuTheme");
        //Player1.instance.gameObject.SetActive(false);
        //Player2.instance.gameObject.SetActive(false);

    }
    private void Update()
    {
        //! Checking if players is active in scene or not
        if (Player1.instance.gameObject.activeInHierarchy == true)
        {
            Player1.instance.gameObject.SetActive(false);
        }
        if (Player2.instance.gameObject.activeInHierarchy == true)
        {
            Player2.instance.gameObject.SetActive(false);
        }               
    }

    public void ClickSound()
    {
        AudioManager.instance.PlaySound("MenuClickSound");
    }

}
