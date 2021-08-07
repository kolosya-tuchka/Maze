using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpaceForParticles : MonoBehaviour
{
    void Start()
    {
        var part = GetComponent<ParticleSystem>();
        var map = FindObjectOfType<MapControls>().transform;
        var main = part.main;
        main.customSimulationSpace = map;
    }
}
