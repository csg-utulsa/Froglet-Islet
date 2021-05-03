using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : Singleton<SoundFXController> { 
    public List<AudioClip> soundFX = new List<AudioClip>();
    public List<AudioClip> sounds { get { return soundFX; } }
    AudioSource playSong;
    public AudioClip walking;

    public AudioClip GetItemByID(int i)
    {
        if (i < 0 && i >= soundFX.Count)
        {
            return null;
        }

        return soundFX[i];


    }
    public void isWalking(bool i)
    {
        playSong.clip = walking;
        if (i)
        {
            if(!playSong.isPlaying)
            playSong.Play();
            playSong.pitch = 0.5f;
        }
        else
        {
            playSong.pitch = 1.0f;
        }
        playSong.loop = i;
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
