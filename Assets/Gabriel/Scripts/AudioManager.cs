using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

[System.Serializable]
public class AudioManager : MonoBehaviour {

    public List<Sounds> sounds = new List<Sounds>();
    // Use this for initialization
    private void Awake()
    {
        //for each sound in the array, just set the prorperties properly
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string nameIn)    
        => sounds.FirstOrDefault(x=>x.name == nameIn).source.Play();
}
