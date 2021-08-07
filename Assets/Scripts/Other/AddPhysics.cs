using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhysics : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        StartCoroutine(Add());
    }

    IEnumerator Add()
    {
        yield return new WaitUntil(() => manager.IsGameOver);
        Destroy(gameObject, 15);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
