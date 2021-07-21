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
        manager = GameObject.Find("Game Manager").GetComponent<HoppersManager>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            firework.transform.position = transform.position;
            firework.Play();
            manager.score++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            firework.Play();
            manager.hoppers--;
            Destroy(GetComponent<Rigidbody>());
            other.transform.parent.parent.GetComponent<HopperPrefab>().HopTop.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
