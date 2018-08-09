using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateManager : PlayerVariableManager {

	public enum GAMESTATE
    {
        CHOOSING_SKILL = 0,
        CHOOSING_TARGET,
        EXECUTE_SKILL,
        PAUSED
    }

	void Start ()
    {
        gameState = GAMESTATE.CHOOSING_SKILL;	
	}
}
