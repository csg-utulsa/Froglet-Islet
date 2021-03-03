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
    public List<Color> colorList;
    public List<Sprite> bubbleList;
    public List<Sprite> noteList;
    public bool gameActive = false;


    Image frogImage, bubbleImage, noteImage, fluteImage;
    Text infoText;
    bool listening, attempting, hasFluteOut, didItCorrectly;
    float timePerNote;
    float pitchOffset;
    List<int> parsedRhythm;
    AudioClip sound;

    float timeCountUp;
    int index;

    AudioControllerScript audioController;

    // Start is called before the first frame update
    void Start()
    {
        if(src == null)
            src = GetComponent<AudioSource>();

        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioControllerScript>();

        frogImage = rhythmGameCanvas.transform.Find("FrogImage").GetComponent<Image>();
        fluteImage = rhythmGameCanvas.transform.Find("FluteImage").GetComponent<Image>();
        bubbleImage = frogImage.transform.Find("BubbleImage").GetComponent<Image>();
        noteImage = bubbleImage.transform.Find("NoteImage").GetComponent<Image>();
        infoText = rhythmGameCanvas.transform.Find("InfoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            if (hasFluteOut)
                fluteImage.gameObject.SetActive(true);
            if (listening)
            {
                foreach (Button b in buttonList)
                    if (b.interactable) b.interactable = false;
                infoText.color = Color.white;
                infoText.text = "Listening";
                timeCountUp += Time.deltaTime;
                if (timeCountUp >= timePerNote)
                {
                    timeCountUp = 0;
                    if (index >= parsedRhythm.Count)
                    {
                        foreach (Button b in buttonList)
                            if (!b.interactable) b.interactable = true;
                        listening = false;
                        attempting = true;
                        didItCorrectly = true;
                        infoText.text = "Go!";
                        index = 0;
                    }
                    else
                    {
                        PlayNote(parsedRhythm[index]);
                        index++;
                    }
                    
                }
            } else if (attempting)
            {
                bubbleImage.transform.localScale = Vector3.zero;
                timeCountUp += Time.deltaTime;
                if (hasFluteOut)
                {
                    KeyboardHandler();
                    if (index >= parsedRhythm.Count)
                    {
                        foreach (Button b in buttonList)
                            b.interactable = false;
                        if (timeCountUp >= timePerNote)
                        {
                            if (didItCorrectly)
                                StopRhythmGame(true);
                            else
                                Listen();
                        }
                    }
                }
                if (timeCountUp >= timePerNote * 8)
                {
                    Listen();
                }
            }
        }
    }

    void PlayNote(int note)
    {
        if (listening)
        {
            bubbleImage.transform.localScale = Vector3.one;
            bubbleImage.sprite = bubbleList[UnityEngine.Random.Range(0, bubbleList.Count - 1)];
            bubbleImage.transform.localEulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(-30f, 10f));
            noteImage.sprite = noteList[UnityEngine.Random.Range(0, noteList.Count - 1)];
            noteImage.color = colorList[note];
        }
        if (note != 0)
        {
            src.volume = 1;
            src.pitch = pitchOffset * Mathf.Pow(2, (note - 1) / 12f);
            audioController.PlaySound(src);
        }
    }

    public void StartRhythmGame(Frog f)
    {
        hasFluteOut = false;
        rhythmGameCanvas.gameObject.SetActive(true);
        bubbleImage.transform.localScale = Vector3.zero;
        SetButtonColors();
        Rhythm r = f.frogMelody;
        sound = f.frogCry;
        //frogImage.sprite = f.sprite;
        if (sound == null)
            sound = debugSound;
        src.clip = sound;
        timePerNote = ConvertTempo(r.tempo, r.subdivision);
        pitchOffset = CalcLowestNote(r.lowestNote);
        if (ParseRhythm(r.rhythm))
        {
            hasFluteOut = true; ////////////////////////////////////THIS IS TEMPORARY!!!    bool should be set when you select from inventory
            gameActive = true;
            Listen();
        }
    }

    public void StopRhythmGame(bool didCorrect)
    {
        if (didCorrect) { } ////////////////////////////////////THIS IS TEMPORARY!!!    this is where youll call things like adding frog to journal

        rhythmGameCanvas.gameObject.SetActive(false);
        hasFluteOut = false;
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
        StopRhythmGame(false);
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
            infoText.color = Color.red;
            infoText.text = "Wrong Note!";
            return false;
        }
        if (index == 0)
            offBy = 0;
        else
            offBy -= timeCountUp;
        if (Mathf.Abs(offBy) > 0.1f)
        {
            if (offBy > 0)
            {
                infoText.color = Color.red;
                infoText.text = "Too Early!";
            }
            else
            {
                infoText.color = Color.red;
                infoText.text = "Too Late!";
            }
            return false;
        }
        infoText.color = Color.white;
        infoText.text = "Good Job!";
        return true;

    }

    void SetButtonColors()
    {
        buttonList[0].GetComponent<Image>().color = colorList[1];
        buttonList[1].GetComponent<Image>().color = colorList[3];
        buttonList[2].GetComponent<Image>().color = colorList[5];
        buttonList[3].GetComponent<Image>().color = colorList[6];
    }


    void KeyboardHandler()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClickNote(1);
            buttonList[0].interactable = false;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ClickNote(3);
            buttonList[1].interactable = false;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ClickNote(5);
            buttonList[2].interactable = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ClickNote(6);
            buttonList[3].interactable = false;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            buttonList[0].interactable = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            buttonList[1].interactable = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            buttonList[2].interactable = true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            buttonList[3].interactable = true;
        }
    }

}
