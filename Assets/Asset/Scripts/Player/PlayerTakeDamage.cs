using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {

    [SerializeField]private GameObject PopUpText;
    List<GameObject> statuses;
    List<GameObject> artifacts;
    public float injuredAnimationTimer;
    public void PlayerDamage(int damage)
    {
        if(GetComponent<PlayerStats>().knockedOut)
        {
            return;
        }
        artifacts = GetComponent<PlayerVariableManager>().artifactsList;
        for (int i=0;i<artifacts.Count;i++)
        {
            if(artifacts[i].GetComponent<ArtifactEffect>() is ShieldOfTheFallenKing && GetComponent<PlayerStats>().name == "OldGuard")
            {
                if(artifacts[i].GetComponent<ShieldOfTheFallenKing>().damageCount>=10)
                {
                    damage = 0;
                    artifacts[i].GetComponent<ShieldOfTheFallenKing>().damageCount = 0;
                }
                else
                {
                    artifacts[i].GetComponent<ShieldOfTheFallenKing>().damageCount++;
                }
                break;
            }
        }
        float multiplier = 1;
        statuses = GetComponent<PlayerVariableManager>().statusList;
        if(statuses.Count>0)
        {
            for (int i = statuses.Count-1; i >= 0; i--)
            {
                if (statuses[i].GetComponent<StatusDetail>() is Berserk)
                {
                    multiplier *= 1.5f;
                }
                if (statuses[i].GetComponent<StatusDetail>() is Confuse)
                {
                    multiplier *= 1.15f;
                }
            }
        }
        GetComponent<PlayerStats>().health -= (int)(damage * multiplier);
        PopUpDamage(gameObject, (int)(damage * multiplier), Color.red);
        if (GetComponent<PlayerStats>().health <= 0)
        {
            return;
        }
        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().injuredAnimation);
        Invoke("ResetAnimation", injuredAnimationTimer);
    }

    public void PlayerHeal(int heal)
    {
        if (GetComponent<PlayerStats>().knockedOut)
        {
            return;
        }
        GetComponent<PlayerStats>().health += heal;
        PopUpDamage(gameObject, heal, Color.green);
    }

    public void PopUpDamage(GameObject target, int damage, Color colour)
    {
        GameObject newPopUp = Instantiate(PopUpText, new Vector3(target.transform.position.x, target.transform.position.y + 2f, target.transform.position.z), Quaternion.identity);
        newPopUp.SetActive(true);
        newPopUp.GetComponent<PopUpDamageController>().SetText(damage.ToString(), colour);
        Destroy(newPopUp.gameObject, 0.5f);
    }

    void ResetAnimation()
    {
        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().idleAnimation);
    }
}
