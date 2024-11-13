using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffleControl : MonoBehaviour
{
    Rigidbody rb;
    private float jumpSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }
}
