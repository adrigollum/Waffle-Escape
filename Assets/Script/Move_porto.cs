using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_porto : MonoBehaviour
{
    Rigidbody rb;
    public float speed_porto= 3f;
	private bool IsRun;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
		
		

		rb.velocity = Vector2.left * speed_porto;

		Debug.Log(speed_porto);

		if (transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
    }
}
