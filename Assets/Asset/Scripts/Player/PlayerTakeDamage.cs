using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {

    [SerializeField]private GameObject PopUpText;
    List<GameObject> statuses;
    public void PlayerDamage(int damage)
    {
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
    }

    public void PlayerHeal(int heal)
    {
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
}
