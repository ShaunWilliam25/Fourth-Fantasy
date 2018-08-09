using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;
    public List<Sound> soundPlaying;
    public int waveIndex = -1;
    public int player1CharacterIndex;
    public int player2CharacterIndex;
    public bool isResetSkill = true;
    public bool isTutorial = true;
    public bool isNewGame = true;

    public static AudioManager Instance
    {
        get{
            return instance;
        }
        
    }

    private void Awake()
    {
        if(instance!=null && instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.isLoop;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void PlaySound(string soundName)
    {
        
        //Sound s = Array.Find(sounds, sound => sound.name == soundName);
       // s.source.Play();
        for(int i=0;i<sounds.Length;i++)
        {
            if(sounds[i].name == soundName)
            {
                Sound s = sounds[i];
                s.source.Play();
                soundPlaying.Add(s);
                return;
            }
        }
    }

    public float VolumeTodB(float volume)
    {
        float db;

        if (volume != 0)
            db = 20.0f * Mathf.Log10(volume);
        else
            db = -144.0f;

        return db;
    }

    public float dBToVolume(float dB)
    {
        float volume;

        volume = Mathf.Pow(10.0f, dB / 20.0f);

        return volume;
    }
    
    /*private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);

        return linear;
    }*/

    //! Play sound from other script by using-> FindObjectofType("AudioManager").Play(soundName);
}
