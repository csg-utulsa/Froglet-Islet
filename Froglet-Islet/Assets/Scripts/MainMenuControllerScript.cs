using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public GameObject mainViewObjectsParent;
    List<GameObject> mainViewObjects = new List<GameObject>();
    public GameObject creditsViewObjectsParent;
    List<GameObject> creditsViewObjects = new List<GameObject>();
    
    public CreditsScript creditsS;

    private void Awake()
    {
        foreach (Transform t in mainViewObjectsParent.GetComponentsInChildren<Transform>())
            mainViewObjects.Add(t.gameObject);
        foreach (Transform t in creditsViewObjectsParent.GetComponentsInChildren<Transform>())
            creditsViewObjects.Add(t.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchViews(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void SwitchViews(int n) // 0 is main, 1 is credits
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
                creditsS.RunCredits();
                break;
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
