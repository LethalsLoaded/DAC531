using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
[System.Serializable]
public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;
    // Use this for initialization
    private void Awake()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Array.Find(sounds, sounds => sounds.name == name).source.Play();
        
    }
}
