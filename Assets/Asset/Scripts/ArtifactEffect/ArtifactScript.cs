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
	public GameObject createdArtifact;
    public List<GameObject> createdArtifactList;

    public void calArtifact()
    {
        int calArtifactChance = Random.Range(0, 100);

        if (calArtifactChance <= normalRarity)
        {
            int randNum = Random.Range(0, normalArtifact.Count);
            createdArtifact = Instantiate(normalArtifact[randNum].items, transform.position, Quaternion.identity);
            normalArtifact.Remove(normalArtifact[randNum]);
            createdArtifactList.Add(createdArtifact);
        }
        else if (calArtifactChance > normalRarity && calArtifactChance <= normalRarity + rareRarity)
        {
            int randNum = Random.Range(0, rareArtifact.Count);
            createdArtifact = Instantiate(rareArtifact[randNum].items, transform.position, Quaternion.identity);
            rareArtifact.Remove(rareArtifact[randNum]);
            createdArtifactList.Add(createdArtifact);
        }
        else if (calArtifactChance > normalRarity + rareRarity && calArtifactChance <= normalRarity + rareRarity + veryRareRarity)
        {
            int randNum = Random.Range(0, veryRareArtifact.Count);
            createdArtifact = Instantiate(veryRareArtifact[randNum].items, transform.position, Quaternion.identity);
            veryRareArtifact.Remove(veryRareArtifact[randNum]);
            createdArtifactList.Add(createdArtifact);
        }
    }
}