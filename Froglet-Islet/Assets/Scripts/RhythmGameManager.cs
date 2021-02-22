//made by Sam Locicero


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGameManager : MonoBehaviour
{
    public Canvas rhythmGameCanvas;
    public AudioSource src;
    public AudioClip debugSound;
    public List<Button> buttonList;


    public bool gameActive = false;
    bool listening = false;
    bool attempting = false;
    bool didItCorrectly;
    float timePerNote;
    float pitchOffset;
    List<int> parsedRhythm;
    AudioClip sound;
    Text infoText;

    float timeCountUp;
    int index;

    AudioControllerScript audioController;

    // Start is called before the first frame update
    void Start()
    {
        if(src == null)
            src = GetComponent<AudioSource>();

        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioControllerScript>();


        infoText = rhythmGameCanvas.transform.Find("InfoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            if (listening)
            {
                infoText.text = "Listening";
                timeCountUp += Time.deltaTime;
                if (timeCountUp >= timePerNote)
                {
                    timeCountUp = 0;
                    PlayNote(parsedRhythm[index]);
                    index++;
                    if (index >= parsedRhythm.Count)
                    {
                        foreach (Button b in buttonList)
                            b.interactable = true;
                        listening = false;
                        attempting = true;
                        didItCorrectly = true;
                        infoText.text = "Go!";
                        index = 0;
                    }
                }
            } else if (attempting)
            {
                timeCountUp += Time.deltaTime;
                if (index >= parsedRhythm.Count)
                {
                    foreach (Button b in buttonList)
                        b.interactable = false;
                    if (timeCountUp >= timePerNote)
                    {
                        if (didItCorrectly)
                            StopRhythmGame();
                        else
                            Listen();
                    }
                }
            }
        }
    }

    void PlayNote(int note)
    {
        if (note != 0)
        {
            src.volume = 1;
            src.pitch = pitchOffset * Mathf.Pow(2, (note - 1) / 12f);
            audioController.PlaySound(src);
        }
    }

    public void StartRhythmGame(Frog f)
    {
        rhythmGameCanvas.gameObject.SetActive(true);
        Rhythm r = f.frogMelody;
        sound = f.frogCry;
        if (sound == null)
            sound = debugSound;
        src.clip = sound;
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
        rhythmGameCanvas.gameObject.SetActive(false);
        listening = false;
        attempting = false;
        gameActive = false;
    }


    public void Listen()
    {
        attempting = false;
        listening = true;
        timeCountUp = 0;
        index = 0;
    }

    float ConvertTempo(int ogTempo, Subdivision sub)
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

    bool ParseRhythm(string rhythm)
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
        StartRhythmGame(GameObject.Find("DebugFrog").GetComponent<Frog>());
    }


    float CalcLowestNote(LowestNote n)
    {
        float pitch = Mathf.Pow(Mathf.Pow(2, 1f / 12f), n.noteOffset + (n.octave - 4) * 12);
        return pitch;
    }

    public void ClickNote(int note)
    {
        PlayNote(note);
        if (!CheckIfCorrect(note))
            didItCorrectly = false;
        timeCountUp = 0;
        index++;
    }

    bool CheckIfCorrect(int note)
    {
        float offBy = timePerNote;
        while (parsedRhythm[index] == 0)
        {
            index++;
            offBy += timePerNote;
        }
        if (parsedRhythm[index] != note)
        {
            infoText.text = "Wrong Note!";
            return false;
        }
        if (index == 0)
            offBy = 0;
        else
            offBy -= timeCountUp;
        Debug.Log(offBy);
        if (Mathf.Abs(offBy) > 0.1f)
        {
            if (offBy > 0)
                infoText.text = "Too Early!";
            else
                infoText.text = "Too Late!";
            return false;
        }
        infoText.text = "Good Job!";
        return true;

    }

}
