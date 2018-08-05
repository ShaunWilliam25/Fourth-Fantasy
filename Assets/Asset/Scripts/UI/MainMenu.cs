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
        UnityEngine.SceneManagement.SceneManager.LoadScene(19); ///get the next level after pressting start
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
        if (AudioManager.Instance.soundPlaying.Count > 0)
        {
            for (int i = 0; i < AudioManager.Instance.soundPlaying.Count; i++)
            {
                AudioManager.Instance.soundPlaying[i].source.Stop();
            }
            AudioManager.Instance.soundPlaying.Clear();
        }                
        AudioManager.instance.PlaySound("MenuTheme");
        AudioManager.instance.waveIndex = -1;

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
