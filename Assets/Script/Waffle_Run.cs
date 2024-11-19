using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waffle_Run : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField] private float Speed = 2f;
	private bool IsRun = false;
	private int multiplier ;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update()
	{

		if (Input.GetMouseButton(1))
		{
			IsRun = true;
			if (transform.position.x <= 2)
			{
				gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);
			}

		}

		if (Input.GetMouseButtonUp(1))
		{
			IsRun = false;

		}

		if (IsRun == false && transform.position.x >=-8)
		{
			gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime);

		}



	}



}
