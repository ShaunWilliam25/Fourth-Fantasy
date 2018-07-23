using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleLog : MonoBehaviour
{

    /*//private VARS
    // public List<> eventlog = new List<string>();
    public GUIText GUIText;
    public List<PlayerLockInSkill> eventLog = new List<PlayerLockInSkill>();

    // public vars
    public int maxLines = 1; //hpw many lines to add in the log

    void OnGUI()
    {//set the rect for the gui print
       //GUIText.GetComponent<GUIText>(GUI.Label(new Rect(0, Screen.height - (Screen.height / 5), Screen.width, Screen.height / 5), GetComponent<GUIText>(), GUI.skin.textArea)) ;
    }

    //get component 
    public PlayerBattleLog EventLog;

    void Start() //call the addevent-eventString
    {
        //eventLog =GetComponent<PlayerBattleLog>(); //add eventString
        //eventLog =GetComponent<PlayerLockInSkill>(); //add eventString
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) ///player actions
        {
           // eventLog.AddEvent("leftBullet");
        }


        if (Input.GetKey(KeyCode.Z))
        {
            //eventLog.AddEvent("rightBullet");
        }
    }

   /* private void AddEvent(string v)
    {
        throw new NotImplementedException();
    }*/

    /*
    public void PlayerBattleLog(string playerButtonplayerButton)
    {
        Eventlog.Add(playerButton);

        if (Eventlog.Count >= 5)
            Eventlog.RemoveAt(0);

        guiText = "Player execute:";///insert the action

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";//next line
        }
    }*/

    // private VARS
    private List<string> eventList = new List<string>();
    private new string guiText = "";

    // public vars
    public int maxLines = 2; //hpw many lines to add in the log
    //public string playerButton;

    void OnGUI()
    {//set the rect for the gui print
     //GUI.Label(new Rect(0, Screen.height - (Screen.height / 3), Screen.width, Screen.height / 3), guiText, GUI.skin.textArea);
        //GUI.Label(new Rect(0, 1, Screen.width, (Screen.height / 3) + 1), guiText, GUI.skin.textArea);
    }

    //get component 
    private PlayerBattleLog eventLog;

    void Start() //call the addevent-eventString
    {
        //eventLog = GetComponent<playerLog>(); //add eventString
    }

    void Update()
    {
        //GetKey(KeyCode.Joystick1Button0)
        /*if (Input.GetKeyDown(KeyCode.A)) ///player actions
        {
            AddEvent("Player used healing on player 2");
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            AddEvent("Player attacks enemy 1");
        }*/
    }

    //example
    public void AddEvent(string eventString)
    {
        eventList.Add(eventString);

        if (eventList.Count >= maxLines)
            eventList.RemoveAt(0);

        guiText = "";///insert the action

        foreach (string logEvent in eventList)
        {
            guiText += logEvent;
            guiText += "\n";//next lne
        }
    }


}





/*example
public void AddEvent(string eventString)
{
    Eventlog.Add(eventString);

    if (Eventlog.Count >= maxLines)
        Eventlog.RemoveAt(0);

    guiText = "";///insert the action

    foreach (string logEvent in Eventlog)
    {
        guiText += logEvent;
        guiText += "\n";//next lne
    }
}*/
