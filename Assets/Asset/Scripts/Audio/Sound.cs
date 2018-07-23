using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    [Tooltip("Audio source file")]
    public AudioClip clip;
    [Tooltip("Volume of the audio")]
    [Range(0f,1f)]
    public float volume;
    [Tooltip("Name used to play sound by script")]
    public string name;
    [Tooltip("Does the audio loop")]
    public bool isLoop;
    [Tooltip("Category of audio,music or effect")]
    public AudioMixerGroup mixer;
    
    [HideInInspector]
    public AudioSource source;
}
