using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshes : MonoBehaviour
{
    GameObject skin, trail;
    private void Start()
    {
        var stats = FindObjectOfType<PlayerStats>();
        skin = stats.skin;
        trail = stats.trail;
        ActivateMesh(skin);
        ActivateMesh(trail);
    }

    void ActivateMesh(GameObject obj)
    {
        if (obj == null) return;

        var mesh = Instantiate(obj, transform.position, transform.rotation);
        mesh.transform.parent = transform;
        mesh.transform.localPosition = obj.transform.position;

        if (obj == trail && GetComponent<PlayerControls3D>() != null)
        {
            GetComponent<PlayerControls3D>().trail = obj.GetComponent<ParticleSystem>();
        }
    }
 
}
