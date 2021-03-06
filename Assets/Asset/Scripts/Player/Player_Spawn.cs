﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour {

    public List<int> characterIndex = new List<int>(2);
    [SerializeField] List<PlayerScriptableObject> characterList;
    public SceneManager sceneManager;
    //public List<GameObject> allSkillList;
    public float skillOffset;
    [SerializeField] private float skillPosOffset;
    private bool resetScene = false;
    [SerializeField] bool isCharacterStatsModified = false;

    private void Awake()
    {
        sceneManager = this.gameObject.GetComponent<SceneManager>();
    }

    private void Update()
    {
        if(!isCharacterStatsModified)
        {
            //! Setting the values for players
            characterIndex[0] = AudioManager.instance.player1CharacterIndex;
            characterIndex[1] = AudioManager.instance.player2CharacterIndex;

            for (int i = 0; i < this.gameObject.GetComponent<SceneManager>().playerList.Count; i++)
            {
                switch (characterIndex[i])
                {
                    case 0:
                        sceneManager.playerList[i].GetComponent<PlayerStats>().name = characterList[0].name;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth = characterList[0].maxHealth;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().health = characterList[0].maxHealth;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characterList[0].sprite;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = characterList[0].animator;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList = characterList[0].skillList;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().idleAnimation = characterList[0].idleAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().attackAnimation = characterList[0].attackAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().injuredAnimation = characterList[0].injuredAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().spellAnimation = characterList[0].spellAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().deathAnimation = characterList[0].deathAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().reviveAnimation = characterList[0].reviveAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().attackAnimationTimer = characterList[0].attackAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().spellAnimationTimer = characterList[0].spellAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerTakeDamage>().injuredAnimationTimer = characterList[0].injuredAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerDeadAndRevive>().reviveAnimationTimer = characterList[0].reviveAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerScrollSkill>().isScroll = 0;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().isAttack = 0;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(characterList[0].scale, characterList[0].scale, characterList[0].scale);
                        break;
                    case 1:
                        sceneManager.playerList[i].GetComponent<PlayerStats>().name = characterList[1].name;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth = characterList[1].maxHealth;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().health = characterList[1].maxHealth;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characterList[1].sprite;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = characterList[1].animator;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList = characterList[1].skillList;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().idleAnimation = characterList[1].idleAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().attackAnimation = characterList[1].attackAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().injuredAnimation = characterList[1].injuredAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().spellAnimation = characterList[1].spellAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().deathAnimation = characterList[1].deathAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().reviveAnimation = characterList[1].reviveAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().attackAnimationTimer = characterList[1].attackAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().spellAnimationTimer = characterList[1].spellAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerTakeDamage>().injuredAnimationTimer = characterList[1].injuredAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerDeadAndRevive>().reviveAnimationTimer = characterList[1].reviveAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerScrollSkill>().isScroll = 0;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().isAttack = 0;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(characterList[1].scale, characterList[1].scale, characterList[1].scale);
                        break;

                    case 2:
                        sceneManager.playerList[i].GetComponent<PlayerStats>().name = characterList[2].name;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth = characterList[2].maxHealth;
                        sceneManager.playerList[i].GetComponent<PlayerStats>().health = characterList[2].maxHealth;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characterList[2].sprite;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = characterList[2].animator;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList = characterList[2].skillList;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().idleAnimation = characterList[2].idleAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().attackAnimation = characterList[2].attackAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().injuredAnimation = characterList[2].injuredAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().spellAnimation = characterList[2].spellAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().deathAnimation = characterList[2].deathAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerVariableManager>().reviveAnimation = characterList[2].reviveAnimation;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().attackAnimationTimer = characterList[2].attackAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().spellAnimationTimer = characterList[2].spellAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerTakeDamage>().injuredAnimationTimer = characterList[2].injuredAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerDeadAndRevive>().reviveAnimationTimer = characterList[2].reviveAnimationTimer;
                        sceneManager.playerList[i].GetComponent<PlayerScrollSkill>().isScroll = 0;
                        sceneManager.playerList[i].GetComponent<PlayerSkillExecution>().isAttack = 0;
                        sceneManager.playerList[i].transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(characterList[2].scale, characterList[2].scale, characterList[2].scale);
                        break;
                }
            }

            //! Make sure the color is white 
            for(int i=0;i<sceneManager.playerList.Count;i++)
            {
                if(sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color != Color.white)
                {
                    sceneManager.playerList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            if (AudioManager.instance.isResetSkill)
            {
                //! For each player
                for (int i = 0; i < sceneManager.playerList.Count; i++)
                {
                    for(int x = 0;x<sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList.Count;x++)
                    {
                        Destroy(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[x]);
                    }
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList.Clear();
                    for (int k = 0; k<sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Count;k++)
                    {
                        Destroy(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder[k]);
                    }
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Clear();
                    if (sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Count < 5)
                    {
                        //! Loop to instantiate skills
                        for (int j = 0; j < sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList.Count; j++)
                        {
                            sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Add(Instantiate(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList[j], new Vector2((sceneManager.playerList[i].transform.GetChild(1).position.x + (skillOffset * j) * 0.6f) - skillPosOffset, sceneManager.playerList[i].transform.GetChild(1).position.y), Quaternion.identity, sceneManager.playerList[i].transform.GetChild(1)));
                        }
                    }
                }
                AudioManager.instance.isResetSkill = false;
            }

            //! Changing the character index based on the one from character selection
            if (!resetScene)
            {
                //! Filling the empty reference that is scene specific
                for (int i = 0; i < sceneManager.playerList.Count; i++)
                {
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().battleLogScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<battleLog>();
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().isTargetLockedIn = false;
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().statusList.Clear();
                    sceneManager.playerList[i].GetComponent<PlayerStatusList>().statusIcon.Clear();
                    sceneManager.playerList[i].GetComponent<actionTimeBar>().timeRequired = 3f;
                    sceneManager.playerList[i].GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().idleAnimation);

                    sceneManager.playerList[i].GetComponent<PlayerStats>().health = sceneManager.playerList[i].GetComponent<PlayerStats>().baseHealth;
                    sceneManager.playerList[i].GetComponent<PlayerStats>().Reset();

                    // Detect Start of Battle to give effect

                    for (int k = 0; k < sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList.Count; k++)
                    {
                        if (sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is SprintShoes || sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is AlchemistSecretElixir || sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is AncientBookOfIntelligence
                                || sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is HeartOfTheDemonLord || sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is ChronosLostMemento || sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>() is ShieldOfTheFallenKing)
                        {
                            sceneManager.playerList[i].GetComponent<PlayerVariableManager>().artifactsList[k].GetComponent<ArtifactEffect>().isEffect = false;
                        }
                    }

                    //! Skill effect reference
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < sceneManager.playerList[i].transform.GetChild(1).GetChild(2 + j).GetComponent<SkillDetail>().skillExecutionHolder.Count; k++)
                        {
                            sceneManager.playerList[i].transform.GetChild(1).GetChild(2 + j).GetComponent<SkillDetail>().skillExecutionHolder[k].GetComponent<SkillEffect>().playerList = sceneManager.playerList;
                            sceneManager.playerList[i].transform.GetChild(1).GetChild(2 + j).GetComponent<SkillDetail>().skillExecutionHolder[k].GetComponent<SkillEffect>().enemyList = sceneManager.enemyList;
                            if(sceneManager.playerList[i].transform.GetChild(1).GetChild(2 + j).GetComponent<SkillDetail>().skillExecutionHolder[k].GetComponent<SkillEffect>() is HealUpgrade4)
                            {
                                sceneManager.playerList[i].transform.GetChild(1).GetChild(2 + j).GetComponent<SkillDetail>().skillExecutionHolder[k].GetComponent<HealUpgrade4>().effect = false;
                            }
                        }
                    }
                }
                resetScene = true;
            }
            isCharacterStatsModified = true;
        }       
    }
}
