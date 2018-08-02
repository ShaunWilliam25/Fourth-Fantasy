using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleLog : MonoBehaviour

{
    // private VARS
    private List<string> eventList = new List<string>();
    private new string guiText = "";
    public GUISkin skin;
    public bool ShowGui = true;
    public TutorialAppear tutorialAppear;

    // public vars
    public int maxLines = 6; //hpw many lines to add in the log
    public string playerButton;

    void OnGUI()
    {
        if(tutorialAppear.tutorialStage != TutorialAppear.TUTORIAL_STAGE.STAGE_01 && tutorialAppear.tutorialStage != TutorialAppear.TUTORIAL_STAGE.STAGE_02 && tutorialAppear.tutorialStage != TutorialAppear.TUTORIAL_STAGE.STAGE_04 && tutorialAppear.tutorialStage != TutorialAppear.TUTORIAL_STAGE.THE_END)
        {
            if(ShowGui)
            {
                GUI.skin = skin;
                GUI.Label(new Rect(250, 10, 700, 95), guiText, GUI.skin.textArea);
            }
            
        }
        /*if (ShowGui)
        {
            GUI.skin = skin;
            GUI.Label(new Rect(250, 10, 750, 100), guiText, GUI.skin.textArea);
        }*/
    }

    //get component 
    public battleLog eventLog;
    private readonly string playerLockInSkillScript;

    void Update()
    {

    }



    public void AddEvent(string playerLockInSkillScript)
    {
        eventList.Add(playerLockInSkillScript);

        if (eventList.Count >= maxLines)
            eventList.RemoveAt(0);

        guiText = "";///insert the action

        //foreach (string logEvent in eventList)
        foreach (string logEvent in eventList)
        {
            guiText += logEvent;
            guiText += "\n";//next lne
        }
    }

}