using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoseSceneController : MonoBehaviour {

    public GameObject lastselect;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
