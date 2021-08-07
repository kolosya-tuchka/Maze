using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    public AudioSource coinPick, thud, boom, rolling, goal;
    Rigidbody rb;
    bool collWall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            coinPick.Play();
        }

        if (other.CompareTag("Finish") || other.CompareTag("Goal"))
        {
            goal.Play();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            boom.Play();
        }

        if (collision.gameObject.CompareTag("Wall") && !collWall)
        {
            collWall = true;
            if (!thud.isPlaying) thud.Play();
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            rolling.Pause();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            collWall = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (rb.velocity.magnitude >= 3f)
            {
                if (!rolling.isPlaying) rolling.Play();
            }
            else if (rb.velocity.magnitude < 1f)
            {
                rolling.Stop();
            }
        }


        if (collision.gameObject.CompareTag("Wall"))
        {
            collWall = true;
        }
    }
}
