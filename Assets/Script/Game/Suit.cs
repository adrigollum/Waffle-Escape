using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suit : MonoBehaviour
{

	private GameObject jo;
	private float posjox;
	private float posjoy;
	private float dify;
	private float difx;
	private bool IsRun;

	public static float EnemySpeed = 0.3f ;


	// Start is called before the first frame update
	void Start()
    {
		jo = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
		posjoy = jo.transform.position.y;
		dify = posjoy - transform.position.y;
		gameObject.transform.Translate(Vector3.up * dify * Time.deltaTime);

		if (Input.GetMouseButton(1)|| Input.GetKey("left shift"))
		{
			IsRun = true;

		}

		if (Input.GetMouseButtonUp(1)|| Input.GetKeyUp("left shift"))
		{
			IsRun = false;
		}

		posjox = jo.transform.position.x;
		difx = posjox - transform.position.x;
		
		
		if (IsRun == false && jo.transform.position.x <= 0)
		{
			if (Mathf.Abs(difx) <= 2)
			{
				gameObject.transform.Translate(Vector3.right * difx* EnemySpeed * 1.5f * Time.deltaTime);
			}
			gameObject.transform.Translate(Vector3.right * difx* EnemySpeed * Time.deltaTime);
		}

		if (IsRun == true && jo.transform.position.x >= -8)
		{
			difx = -8 - transform.position.x;
			gameObject.transform.Translate(Vector3.right * difx * Time.deltaTime);
		}

		

	}
}
