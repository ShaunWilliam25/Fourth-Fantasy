using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlwaysSelected : MonoBehaviour
{
    EventSystem mainMenuEventSystem;
    public Button exit;

    private void OnEnable()
    {
        mainMenuEventSystem = EventSystem.current;
    }

    void Update ()
    {
		if (mainMenuEventSystem.currentSelectedGameObject == null)
        {
            mainMenuEventSystem.SetSelectedGameObject(mainMenuEventSystem.firstSelectedGameObject);
        }
        
        /*if(Input.GetButtonDown("Cancel"))
        {
            exit.OnSubmit();
        }*/
	}
}
