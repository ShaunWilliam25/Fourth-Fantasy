using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour {
    [SerializeField] Image player1;
    [SerializeField] Image player2;
    [SerializeField] List<Sprite> characterList;

    [SerializeField] float cannotPressTimer = 0f;
    [SerializeField] float cannotPressDuration;
    [SerializeField] bool isCanPress = false;

    // Use this for initialization
    void Start () {

        isCanPress = false;
        player1.sprite = characterList[AudioManager.instance.player1CharacterIndex];
        player2.sprite = characterList[AudioManager.instance.player2CharacterIndex];
    }
	
	// Update is called once per frame
	void Update ()
    {
        cannotPressTimer += Time.deltaTime;

        if(cannotPressTimer >= cannotPressDuration)
        {
            isCanPress = true;
        }

        if (isCanPress)
        {
            if (Input.anyKeyDown)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
        
	}
}
