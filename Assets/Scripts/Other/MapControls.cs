using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControls : MonoBehaviour
{
    GameManager manager;
    private Vector3 point2;
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Physics.gravity *= 8;
    }

    void Update()
    {

        if (!manager.IsGameOver())
        {
            point2 = new Vector3(Input.GetAxis("Mouse Y"), 0, -Input.GetAxis("Mouse X"));

            if (Input.GetMouseButton(0))
            {
                transform.RotateAround(transform.position, point2, 100 * Time.deltaTime);
            }

        }
        else
        {
            Physics.gravity /= 8;
            enabled = false;
        }
        transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        //transform.position = Vector3.zero;
    }

}
