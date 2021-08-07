using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControls : MonoBehaviour
{
    GameManager manager;
    Spawner spawner;
    Generator generator;
    private Vector3 point2;
    int sensivity;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
        spawner = manager.GetComponent<Spawner>();
        generator = manager.GetComponent<Generator>();
        sensivity = manager.playerStats.settings.sensivity;
        Physics.gravity = Vector3.down * 9.81f * 8;
    }

    void Update()
    {
        if (!manager.IsGameOver)
        {
            point2 = new Vector3(Input.GetAxis("Mouse Y"), 0, -Input.GetAxis("Mouse X"));

            if (Input.GetMouseButton(0))
            {
                transform.RotateAround(transform.position + rb.centerOfMass, point2, sensivity * 15 * Time.deltaTime);
            }

        }
        else
        {
            Physics.gravity = Vector3.down * 9.81f;
            enabled = false;
        }
        transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        //transform.position = Vector3.zero;
    }

}
