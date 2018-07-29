using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage1 : MonoBehaviour
{

  //  public int EncyclopediaP0 = 0;
    public int EncyclopediaP1 = 0;//exile
    public int EncyclopediaP2 = 0;//time
    public int EncyclopediaP3 = 0;//old
    public int EncyclopediaP4 = 0;//noble
    public int EncyclopediaP5 = 0;//spiritdoor
    public int EncyclopediaP6 = 0;//wolf
    public int EncyclopediaP7 = 0;//consuming knight
    public int StartMenuFinal = 0;//start

    public void Encyclopedia_ExileDemon()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP1); ///get the next level after pressting next
	}

    public void Encyclopedia_TimePriestess()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP2); ///get the next level after pressting next
	}


    public void Encyclopedia_OldGuard()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP3); ///get the next level after pressting next
	}



    public void Encyclopedia_BleedingNoble()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP4); ///get the next level after pressting next
	}

    public void Encyclopedia_SpiritDoor()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP5); ///get the next level after pressting next
	}

    public void Encyclopedia_Mimic()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP6); ///get the next level after pressting next
	}

    public void Encyclopedia_ConsumingKnight()
    {
        Debug.Log("EncyclopediaTimePriestessNEXT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP7); ///get the next level after pressting next
	}

    //-----------------------------------------------------------------------------------------------------------------------------------------------
    public void Encyclopedia_ExileDemon_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(StartMenuFinal); /// build =0
	}

    public void Encyclopedia_TimePriestess_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP1); ///build=6
	}


    public void Encyclopedia_OldGuard_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP2); ///build=7
	}


    public void Encyclopedia_BleedingNoble_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP3); ///build=8
	}

    public void Encyclopedia_SpiritDoor_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP4); ///build=9
	}

    public void Encyclopedia_Mimic_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP5); ///build=10
	}

    public void Encyclopedia_ConsumingKnight_Back()
    {
        Debug.Log("_Back");
        UnityEngine.SceneManagement.SceneManager.LoadScene(EncyclopediaP6); ///build=11
	}
}
