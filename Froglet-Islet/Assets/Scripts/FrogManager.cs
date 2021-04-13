using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrogManager : MonoBehaviour
{

    private RhythmGameManager rhythmGameManager;
    private bool agentsPaused = false;

    [SerializeField]
    List<GameObject> frogs = new List<GameObject>();

    void Awake(){
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
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
        foreach(var frogObject in frogs){
            if(!frogObject.GetComponent<NavMeshAgent>()) continue;
            frogObject.GetComponent<NavMeshAgent>().isStopped = true;
            // print("Pause " + frogObject.GetComponent<NavMeshAgent>().isStopped);
            
        }
    }

    void ResumeAllFrogs(){
        foreach(var frogObject in frogs){
            if(!frogObject.GetComponent<NavMeshAgent>()) continue;
            frogObject.GetComponent<NavMeshAgent>().isStopped = false;
            // print("Resume " + frogObject.GetComponent<NavMeshAgent>().isStopped);
        }
    }
}
