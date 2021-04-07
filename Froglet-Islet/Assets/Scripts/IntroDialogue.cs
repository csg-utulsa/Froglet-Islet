using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class IntroDialogue : MonoBehaviour
{
    public TMP_Text dialogBox;
    int numClicks;
    public AudioClip frogSounds;
    public AudioSource sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        numClicks = 0;
    }

    public void buttonPress()
    {
        numClicks++;
        switch(numClicks)
        {
            case 0:
                break;
            case 1:
                dialogBox.text = "I guess I'm stuck on this island for now...";
                break;
            case 2:
                dialogBox.text = "How am I going to get out of here!? What about my research?";
                break;
            case 3:
                dialogBox.text = "Wait, what's that sound??";
                sfxPlayer.PlayOneShot(frogSounds, 1f);
                break;
            case 4:
                SceneManager.LoadScene("MainScene");
                break;
        }
    }
}
