using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    [System.Serializable]
    public class ArtifactCurrency
    {
        public string name;
        public GameObject items;
    }

    public List<ArtifactCurrency> normalArtifact = new List<ArtifactCurrency>();
    public List<ArtifactCurrency> rareArtifact = new List<ArtifactCurrency>();
    public List<ArtifactCurrency> veryRareArtifact = new List<ArtifactCurrency>();
    public int normalRarity;
    public int rareRarity;
    public int veryRareRarity;
	public GameObject ownedArtifact;
    public List<GameObject> ownedArtifactList;

    public void calArtifact()
    {
        int calArtifactChance = Random.Range(0, 100);

        if (calArtifactChance <= normalRarity)
        {
            int randNum = Random.Range(0, normalArtifact.Count);
            ownedArtifact = Instantiate(normalArtifact[randNum].items, Vector3.zero, Quaternion.identity);
            ownedArtifactList.Add(ownedArtifact);
            //DestroyImmediate(normalArtifact[randNum].items,true)

            //Instantiate(normalArtifact[randNum].items, transform.position. new Vector2(enemySpawnPoints[i].position.x, enemySpawnPoints[i].position.y), Quaternion.identity);

            // new Vector2([i].position.x, playerSpawnPoints[i].position.y), Quaternion.identity, playerSpawnPoints[i]);

        }
        else if (calArtifactChance > normalRarity && calArtifactChance <= normalRarity + rareRarity)
        {
            int randNum = Random.Range(0, rareArtifact.Count);
			ownedArtifact = Instantiate(rareArtifact[randNum].items, Vector3.zero, Quaternion.identity);
            ownedArtifactList.Add(ownedArtifact);
        }
        else if (calArtifactChance > normalRarity + rareRarity && calArtifactChance <= normalRarity + rareRarity + veryRareRarity)
        {
            int randNum = Random.Range(0, veryRareArtifact.Count);
			ownedArtifact = Instantiate(veryRareArtifact[randNum].items, Vector3.zero, Quaternion.identity);
            ownedArtifactList.Add(ownedArtifact);
        }

        //ownedArtifact.SetActive(false);
    }

    /*public void OnTriggerEnter()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Destroy(gameObject); ///destrols the artifact
        }
    }*/
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    [System.Serializable]
    public class ArtifactCurrency
    {
        public string name;
        public GameObject items;
        public int artifactRarity;
    }

    public List<ArtifactCurrency> ArtifactTable = new List<ArtifactCurrency>();
    public int artifactChance; 
	
	// Update is called once per frame
	public void calArtifact ()
    {
        int calArtifactChance = Random.Range(0, 100);

        if(calArtifactChance > artifactChance)
        {
            Debug.Log("artifact X");
            return;
        }

        if(calArtifactChance <= artifactChance)
        {

            for (int i=0; i< ArtifactTable.Count; i++)
            {
                artifactChance += ArtifactTable [i].artifactRarity; //increase rarity
            }
            Debug.Log(artifactChance);

            int randomValue = Random.Range(0, ArtifactTable.Count); 

            for (int j = 0; j < ArtifactTable.Count; j++)
            {
                if (randomValue <= ArtifactTable[j].artifactRarity)
                {
                    Instantiate(ArtifactTable[j].items, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= ArtifactTable[j].artifactRarity;
                Debug.Log("random value decresed" + randomValue);
            }
        }
	}
}*/
