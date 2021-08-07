using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject persuitObject;
    GameManager manager;
    public float offset = 150;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        transform.position = persuitObject.transform.position - transform.forward * offset;
    }

    void FixedUpdate()
    {
        if (manager.IsGameOver) return;
        transform.position = Vector3.Lerp(transform.position, persuitObject.transform.position - transform.forward * offset, 0.02f);
    }

}
