using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrogManager : MonoBehaviour
{

    private RhythmGameManager rhythmGameManager;
    private bool agentsPaused = false;

    [SerializeField]
    List<GameObject> enabledFrogs = new List<GameObject>();

    List<GameObject> allFrogs = new List<GameObject>();

    [SerializeField]
    float enableDistance = 300f;

    void Awake(){
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Frog[] frogComponents = GameObject.FindObjectsOfType<Frog>();
        foreach(Frog frog in frogComponents){
            allFrogs.Add(frog.gameObject);        
        }

        InvokeRepeating("ManageActiveFrogs",0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rhythmGameManager.gameActive){
            // if(agentsPaused) return;
            PauseAllFrogs();
            agentsPaused = true;
            return;
        }

        if(agentsPaused){
            ResumeAllFrogs();
            agentsPaused = false;
        }
    }

    void PauseAllFrogs(){
        foreach(var frogObject in enabledFrogs){
            if(!frogObject.GetComponent<NavMeshAgent>()) continue;
            frogObject.GetComponent<NavMeshAgent>().isStopped = true;
            // print("Pause " + frogObject.GetComponent<NavMeshAgent>().isStopped);
            
        }
    }

    void ResumeAllFrogs(){
        foreach(var frogObject in enabledFrogs){
            if(!frogObject.GetComponent<NavMeshAgent>()) continue;
            frogObject.GetComponent<NavMeshAgent>().isStopped = false;
            // print("Resume " + frogObject.GetComponent<NavMeshAgent>().isStopped);
        }
    }

    void ManageActiveFrogs(){
        if(agentsPaused) return;
        enabledFrogs.Clear();
        foreach(GameObject frogObject in allFrogs){
            if(Vector3.Distance(PlayerController.Instance.transform.position, frogObject.transform.position) <= enableDistance){
                enabledFrogs.Add(frogObject);
                frogObject.SetActive(true);
            }else{
                frogObject.gameObject.SetActive(false);
                // disabledFrogs.Add(frogObject.gameObject);
            }
        }


    }
}
