using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour {

    [SerializeField] private GameObject PopUpText;
    List<GameObject> statuses;
    [SerializeField] private float injuredAnimationTimer;

    public void EnemyDamage(int damage)
    {
        if(GetComponent<EnemyStats>().health<=0)
        {
            return;
        }
        float multiplier = 1;
        statuses = GetComponent<EnemyVariableManager>().statusList;
        if (statuses.Count > 0)
        {
            for (int i = statuses.Count - 1; i >= 0; i--)
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
        GetComponent<EnemyStats>().health -= (int)(damage * multiplier);
        if(GetComponent<EnemyStats>().health>0)
        {
            GetComponent<EnemyVariableManager>().anim.Play(GetComponent<EnemyVariableManager>().injuredAnimation);
            Invoke("ResetAnimation", injuredAnimationTimer);
        }
        PopUpDamage(gameObject, (int)(damage * multiplier), Color.red);
    }

    public void EnemyHeal(int heal)
    {
        if (GetComponent<EnemyStats>().health <= 0)
        {
            return;
        }
        GetComponent<EnemyStats>().health += heal;
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
        this.GetComponent<EnemyVariableManager>().anim.Play(this.GetComponent<EnemyVariableManager>().idleAnimation);
    }
}
