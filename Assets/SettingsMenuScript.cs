using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float Volume)
    {
        NewMethod(Volume);
        // Debug.Log(volume);
    }

    public void NewMethod(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        //audioMixer.SetFloat("Volume (of Master)", Volume);
    }
}



