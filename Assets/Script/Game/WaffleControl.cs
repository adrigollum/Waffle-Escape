using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffleControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float jumpSpeed = 5f;
	public bool mort = false;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

		

        if (!mort && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")))
        {
            Jump();
        }
	}

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }


	void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag != "gate")
		{
			mort = true;
		}

	}


}
