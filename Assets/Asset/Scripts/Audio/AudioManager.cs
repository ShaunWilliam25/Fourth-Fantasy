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
    public bool isNeedGreedTutorialShown = false;
    public bool isCampsiteTutorialShown = false;
    public bool isNewGameVolume;

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
            isNewGameVolume = true;
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

    //! Play sound from other script by using-> FindObjectofType("AudioManager").Play(soundName);
}
