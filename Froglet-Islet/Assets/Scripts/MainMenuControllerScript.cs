using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControllerScript : MonoBehaviour
{
    public GameObject mainViewObjectsParent;
    List<GameObject> mainViewObjects = new List<GameObject>();
    public GameObject creditsViewObjectsParent;
    List<GameObject> creditsViewObjects = new List<GameObject>();
    public GameObject helpViewObjectsParent;
    List<GameObject> helpViewObjects = new List<GameObject>();

    public CreditsScript creditsS;
    public MenuTongueScript mtS;

    public RectTransform[] buttons;

    const float TONGUE_TIME = 0.5f;

    private void Awake()
    {
        foreach (Transform t in mainViewObjectsParent.GetComponentsInChildren<Transform>())
            mainViewObjects.Add(t.gameObject);
        foreach (Transform t in creditsViewObjectsParent.GetComponentsInChildren<Transform>())
            creditsViewObjects.Add(t.gameObject);
        foreach (Transform t in helpViewObjectsParent.GetComponentsInChildren<Transform>())
            helpViewObjects.Add(t.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ViewChange(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string s)
    {
        mtS.TongueBug(buttons[4]);
        StartCoroutine("DelayLoadScene", s);
    }

    IEnumerator DelayLoadScene(string s)
    {
        yield return new WaitForSeconds(TONGUE_TIME);
        mtS.EndTongueBug();
        SceneManager.LoadScene(s);
    }

    public void SwitchViews(int n) 
    {
        mtS.TongueBug(buttons[n]);

        switch (n)
        {
            case 0: // credits button
                StartCoroutine("DelaySwitchViews", 1);
                break;
            case 1: // credits back button
                StartCoroutine("DelaySwitchViews", 0);
                break;
            case 2: // help button
                StartCoroutine("DelaySwitchViews", 2);
                break;
            case 3: // help back button
                StartCoroutine("DelaySwitchViews", 0);
                break;
        }
        
    }

    IEnumerator DelaySwitchViews(int n)// 0 is main, 1 is credits, 2 is help (switches to)
    {
        yield return new WaitForSeconds(TONGUE_TIME);
        mtS.EndTongueBug();

        ViewChange(n);
    }

    private void ViewChange(int n)
    {
        switch (n)
        {
            case 0:
                foreach (GameObject o in mainViewObjects)
                {
                    o.SetActive(true);
                }
                foreach (GameObject o in creditsViewObjects)
                {
                    o.SetActive(false);
                }
                foreach (GameObject o in helpViewObjects)
                {
                    o.SetActive(false);
                }
                break;

            case 1:
                foreach (GameObject o in mainViewObjects)
                {
                    o.SetActive(false);
                }
                foreach (GameObject o in creditsViewObjects)
                {
                    o.SetActive(true);
                }
                foreach (GameObject o in helpViewObjects)
                {
                    o.SetActive(false);
                }
                creditsS.RunCredits();
                break;
            case 2:
                foreach (GameObject o in mainViewObjects)
                {
                    o.SetActive(false);
                }
                foreach (GameObject o in creditsViewObjects)
                {
                    o.SetActive(false);
                }
                foreach (GameObject o in helpViewObjects)
                {
                    o.SetActive(true);
                }
                creditsS.RunCredits();
                break;
        }
    }

    public void QuitGame()
    {
        StartCoroutine("DelayQuitGame");
        mtS.TongueBug(buttons[5]);
    }

    IEnumerator DelayQuitGame()
    {
        yield return new WaitForSeconds(TONGUE_TIME);
        mtS.EndTongueBug();
        Application.Quit();
    }

}
