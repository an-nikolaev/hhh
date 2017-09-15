using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyRotatorClass : MonoBehaviour {

    public Rigidbody rb;
    public float tumble;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0.0f, Random.Range(0.0f, 180.0f), 0.0f) * tumble;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
