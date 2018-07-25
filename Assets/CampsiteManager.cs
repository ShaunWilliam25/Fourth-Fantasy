using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampsiteManager : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>(2);
    
    private void Start()
    {
        playerList[0] = GameObject.FindWithTag("Player1");
        playerList[1] = GameObject.FindWithTag("Player2");
        playerList[0].SetActive(false);
        playerList[1].SetActive(false);
    }
}
