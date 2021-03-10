/*
    Marker.cs
    Written by: Jacob Regan
    Last Edited: 3/10/2021

    Set the stop condition for the Particle system on the marker to trigger deletion.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_ParticleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            RemoveMarker();
        }
    }

    public void RemoveMarker(){
        m_ParticleSystem.Stop();
        var mainPS = m_ParticleSystem.main;
        mainPS.simulationSpeed = 10f;
    }
}
