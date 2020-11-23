using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyMove : MonoBehaviour
{
    public int rotationSpeed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
}
