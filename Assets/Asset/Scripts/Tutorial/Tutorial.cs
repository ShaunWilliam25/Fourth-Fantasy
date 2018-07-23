using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour{

    public Canvas canvas;

    public void ExitTutorial()
    {
        canvas.gameObject.SetActive(false);
    }

}
