using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlls : MonoBehaviour
{
    public ParticleSystem firework;
    HoppersManager manager;
    Timer timer;
    void Start()
    {
        manager = FindObjectOfType<HoppersManager>();
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (manager.IsGameOver) Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            firework.transform.position = transform.position;
            firework.Play();
            manager.money++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            firework.Play();
            manager.hoppers--;
            manager.score++;
            Destroy(GetComponent<Rigidbody>());
            other.transform.parent.parent.GetComponent<HopperPrefab>().HopTop.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
