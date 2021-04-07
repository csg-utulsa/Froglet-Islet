using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSource;
public class MainAudio : MonoBehaviour
{
    private static MainAudio instance = null;
    private AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}