using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystem : MonoBehaviour
{

   // public ParticleSystem pS1;
   // public ParticleSystem pS2;

    public void Awake()
    {
        GetComponent<ParticleSystem>().Play();
       /* ParticleSystem pS1 = GetComponent<ParticleSystem>();
       
        ParticleSystem.EmissionModule module1 = pS1.emission;
       // ParticleSystem.EmissionModule module2 = pS2.emission;
        module1.enabled = true;
        //module2.enabled = true;*/
    }
}
