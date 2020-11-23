using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhysics : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(Add());
    }

    IEnumerator Add()
    {
        yield return new WaitUntil(manager.IsGameOver);
        gameObject.AddComponent<Rigidbody>();
    }
}
