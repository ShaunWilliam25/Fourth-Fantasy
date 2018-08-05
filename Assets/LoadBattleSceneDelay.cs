using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadBattleSceneDelay : MonoBehaviour
{
    public GameObject countdown;

    void Start()
    {
        StartCoroutine ("BattleScDelay");
    }

    void Update()
    {
       
    }

    IEnumerator BattleScDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;

        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;

        countdown.gameObject.SetActive(false);
        Time.timeScale = 1;

    }


}

/*bool pressToContinue = false;

void Update()
{
    if (pressToContinue)
    {
        if (Input.GetKey(KeyCode.A))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}*/

