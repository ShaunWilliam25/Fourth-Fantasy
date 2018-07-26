using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    public static Player1 instance;

    private void Awake()
    {
        if(instance != null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckScene()
    {
        //! check scene index, if battle scene set active, other inactive
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 6)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
