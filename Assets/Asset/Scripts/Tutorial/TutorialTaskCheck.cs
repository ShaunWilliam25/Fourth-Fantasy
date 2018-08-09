using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTaskCheck : MonoBehaviour {

    [SerializeField] List<Toggle> toggleList;
    TutorialAppear tutorial;  

    private void Awake()
    {
        tutorial = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TutorialAppear>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(tutorial.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_01)
        {
            if (toggleList[0].isOn == true && toggleList[1].isOn == true)
            {
                for (int i = 0; i < toggleList.Count; i++)
                {
                    toggleList[i].isOn = false;
                }
                tutorial.tutorialStage = TutorialAppear.TUTORIAL_STAGE.STAGE_02;
            }
            
        }
        else if (tutorial.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_02)
        {
            if (toggleList[0].isOn == true && toggleList[1].isOn == true)
            {
                for (int i = 0; i < toggleList.Count; i++)
                {
                    toggleList[i].isOn = false;
                    
                }
                tutorial.tutorialStage = TutorialAppear.TUTORIAL_STAGE.STAGE_03;
            }
        }
        else if(tutorial.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_06)
        {
            if(tutorial.taskCanvas.enabled == true)
            {
                if (toggleList[0].isOn == true && toggleList[1].isOn == true)
                {
                    for (int i = 0; i < toggleList.Count; i++)
                    {
                        toggleList[i].isOn = false;
                    }
                    tutorial.taskCanvas.enabled = false;
                    tutorial.isLectureDone = false;
                    tutorial.tutorialStage = TutorialAppear.TUTORIAL_STAGE.STAGE_07;                    
                }
            }            
        }

    }

}
