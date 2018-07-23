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

    private void Awake()
    {
        /*if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }*/

        if(instance!=null && instance != this.gameObject)
        {
            Debug.Log("Time to destory");
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

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
        //PlaySound("TestMusic");
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

    //! Play sound from other script by using-> FindObjectofType("AudioManager").Play(soundName);
}
