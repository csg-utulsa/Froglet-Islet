using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : Singleton<SoundFXController> { 
    public List<AudioClip> soundFX = new List<AudioClip>();
    public List<AudioClip> sounds { get { return soundFX; } }
    AudioSource playSong;

    public AudioClip GetItemByID(int i)
    {
        if (i < 0 && i >= soundFX.Count)
        {
            return null;
        }

        return soundFX[i];


    }

    public void Play(int i)
    {
        
        playSong.clip = GetItemByID(i);
        playSong.Play();
    }

    void Start()
    {
        playSong = GetComponent<AudioSource>();
    }
}
