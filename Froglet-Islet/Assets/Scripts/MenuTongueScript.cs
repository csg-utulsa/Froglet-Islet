using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTongueScript : MonoBehaviour
{
    public RectTransform tran1, tran2;
    Vector2 adjustedTran2; // Cus anchoring and UI in general is a jerk (parenting an object in a Canvas messes with anchoring coordinates)
    Vector2 adjustedTran1; // Because it doesn't use exact point of frog. Closer to the mouth
    RectTransform rectTran;
    Image image;

    float zRotation;

    AudioControllerScript audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioControllerScript>();

        image = GetComponent<Image>();
        image.enabled = false;
        rectTran = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TongueBug(RectTransform t)
    {
        tran2 = t;

        audioS.PlaySound("WhipCrack");
        adjustedTran1 = new Vector2(tran1.anchoredPosition.x, tran1.anchoredPosition.y);
        adjustedTran2 = new Vector2(tran2.anchoredPosition.x, tran2.anchoredPosition.y);
        rectTran.sizeDelta = new Vector2(24f, Vector2.Distance(tran1.anchoredPosition, adjustedTran2));
        //rectTran.anchoredPosition = adjustedTran1 + (adjustedTran2 - adjustedTran1) / 2f;
        rectTran.transform.rotation = Quaternion.identity;
        zRotation = Mathf.Atan((adjustedTran2.y - adjustedTran1.y) / (adjustedTran2.x - adjustedTran1.x)) * Mathf.Rad2Deg + 90f;
        rectTran.Rotate(new Vector3(0, 0, zRotation));
        if (t.gameObject.name == "StartButton" || t.gameObject.name == "QuitButton" || t.gameObject.name == "CreditsBackButton")
            rectTran.localEulerAngles += Vector3.forward * 180;
        image.enabled = true;
    }

    public void EndTongueBug()
    {
        image.enabled = false;
    }
}
