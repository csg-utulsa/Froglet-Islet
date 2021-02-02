//made by Sam Locicero


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public Canvas rhythmGameCanvas;
    public AudioSource src;
    public AudioClip debugSound;


    bool gameActive = false;
    bool listening = false;
    float timePerNote;
    float pitchOffset;
    List<int> parsedRhythm;
    AudioClip sound;

    float timeCountUp;
    int index;



    // Start is called before the first frame update
    void Start()
    {
        if(src == null)
            src = GetComponent<AudioSource>();
        sound = debugSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            if (listening)
            {
                timeCountUp += Time.deltaTime;
                if (timeCountUp >= timePerNote)
                {
                    timeCountUp = 0;
                    PlayNote(parsedRhythm[index]);
                    index++;
                    if (index >= parsedRhythm.Count)
                        listening = false;
                }
            }
        }
    }

    private void PlayNote(int note)
    {
        src.volume = 1;
        src.pitch = pitchOffset * Mathf.Pow(2, (note - 1) / 12f);
        print(src.pitch);
        if (note == 0)
            src.volume = 0f;
        src.PlayOneShot(sound);
    }

    public void StartRhythmGame(GameObject f)
    {
        Rhythm r = f.GetComponent<Rhythm>();
        //sound = f.sound;
        timePerNote = ConvertTempo(r.tempo, r.subdivision);
        pitchOffset = CalcLowestNote(r.lowestNote);
        if (ParseRhythm(r.rhythm))
        {
            gameActive = true;
            Listen();
        }
    }

    public void StopRhythmGame()
    {
        listening = false;
        gameActive = false;
    }


    public void Listen()
    {
        listening = true;
        timeCountUp = 0;
        index = 0;
    }

    public float ConvertTempo(int ogTempo, Subdivision sub)
    {
        Mathf.Clamp(ogTempo, 40, 250);
        float time = 60f / ogTempo;
        if (sub == Subdivision.Eighth)
            time /= 2f;
        else if (sub == Subdivision.Sixteenth)
            time /= 4f;
        else if (sub == Subdivision.Triplet)
            time /= 3f;
        return time;
    }

    public bool ParseRhythm(string rhythm)
    {
        parsedRhythm = new List<int>();

        if (rhythm == "")
        {
            Debug.LogError("Rhythm String is unacceptable");
            return false;
        }

        char[] charArray = rhythm.ToCharArray();
        foreach(char c in charArray)
        {
            int temp;
            if (char.IsNumber(c))
                temp = c - '0';
            else
            {
                switch (c)
                {
                    case 'A':
                        temp = 10;
                        break;
                    case 'B':
                        temp = 11;
                        break;
                    case 'C':
                        temp = 12;
                        break;
                    case 'D':
                        temp = 13;
                        break;
                    default:
                        Debug.LogError("Rhythm String is unacceptable");
                        return false;
                }
                
            }
            parsedRhythm.Add(temp);
        }
        return true;
    }


    public void DebugStart()
    {
        StopRhythmGame();
        StartRhythmGame(GameObject.Find("DebugFrog"));
    }


    public float CalcLowestNote(LowestNote n)
    {
        float pitch = Mathf.Pow(Mathf.Pow(2, 1f / 12f), n.noteOffset + (n.octave - 4) * 12);
        return pitch;
    }
}
