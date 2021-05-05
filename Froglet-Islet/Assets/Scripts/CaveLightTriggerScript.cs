using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLightTriggerScript : MonoBehaviour
{
    Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
        light.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            light.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            light.enabled = false;
    }
}
