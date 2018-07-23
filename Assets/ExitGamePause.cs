using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGamePause : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit Battle");
            Application.Quit();
    }

}
