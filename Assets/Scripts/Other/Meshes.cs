using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshes : MonoBehaviour
{
    public GameObject[] meshes;
    int curSkin;
    private void Start()
    {
        meshes = Resources.LoadAll<GameObject>("Skins");
        curSkin = PlayerPrefs.GetInt("Skin");
        ActivateMesh();
    }

    void ActivateMesh()
    {
        foreach (var obj in meshes)
        {
            if (obj.GetComponent<Mesh>().index == curSkin)
            {
                var mesh = Instantiate(obj, transform.position, transform.rotation);
                mesh.transform.parent = transform;
            }
        }
    }


}
