using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectedCheck : MonoBehaviour {
    [SerializeField] List<LobbyMenu> playerLobbyMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerLobbyMenu[0].isReady && playerLobbyMenu[1].isReady)
        {
            //! Fill the character index in audio manager
            AudioManager.instance.player1CharacterIndex = playerLobbyMenu[0].characterIndex;
            AudioManager.instance.player2CharacterIndex = playerLobbyMenu[1].characterIndex;

            //! Move to tutorial scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(20);
        }
	}
}
