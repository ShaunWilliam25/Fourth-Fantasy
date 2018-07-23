using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseSceneController : MonoBehaviour {

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
