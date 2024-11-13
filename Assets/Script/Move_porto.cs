using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_porto : MonoBehaviour
{
    Rigidbody rb;
    private float speed_porto= 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed_porto;
    }
}
