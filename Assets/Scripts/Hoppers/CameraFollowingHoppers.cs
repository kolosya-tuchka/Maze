using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingHoppers : MonoBehaviour
{
    public GameObject map;
    public Vector3 offset;
    Rigidbody rb;
    void Start()
    {
        rb = map.GetComponent<Rigidbody>();
        transform.position = map.transform.position + rb.centerOfMass + offset;
    }

    void FixedUpdate()
    {
        Vector3 point = map.transform.position + rb.centerOfMass + offset;
        transform.position = Vector3.Lerp(transform.position, point, 0.02f);
    }
}
