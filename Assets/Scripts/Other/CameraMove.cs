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
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(Move());
        transform.position = persuitObject.transform.position - transform.forward * offset;
    }

    IEnumerator Move()
    {
        while (!manager.IsGameOver())
        {
            transform.position = Vector3.Lerp(transform.position, persuitObject.transform.position - transform.forward * offset, 0.02f);
            yield return null;
        }
    }
}
