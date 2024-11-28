using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	[SerializeField] private GameObject waf;
	Rigidbody rb;

	private float dify;
	private float difx;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		dify = waf.transform.position.y - 6 - transform.position.y;
		difx = waf.transform.position.x - transform.position.x;
		gameObject.transform.Translate(Vector3.up * dify);
		/*gameObject.transform.Translate(Vector3.right * difx);*/
	}
}
