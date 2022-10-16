using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager: MonoBehaviour
{
    [Header("MIXER")]
    public AudioMixerGroup mixerGroup;
    [Header("AUDIO")]
    public Soundz[] sounds; 

    public static AudioManager instance;
    public bool dontDestroy; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (dontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }

        foreach (Soundz s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mixerGroup;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; 
        }
    }

    private void Start()
    {
        Play("Background");

    }
     

    public void Play(string soundName)
    {
        Soundz s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.Log("Sound: \"" + soundName + "\" not found!");
            return;
        }

        s.source.Play();
    } 
}
