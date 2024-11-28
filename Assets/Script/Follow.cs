using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour
{
	[SerializeField] private GameObject waf;
	Rigidbody rb;

	private float dify;

	private float secondsLeft;
	private float difx;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		if (waf.transform.position.y >= -125)
		{

		
		dify = waf.transform.position.y - 6 - transform.position.y;
		difx = waf.transform.position.x - transform.position.x;
		gameObject.transform.Translate(Vector3.up * dify);
			/*gameObject.transform.Translate(Vector3.right * difx);*/

		}
		else
		{
			StartCoroutine(DelayLoadlevel(2));
		}
	}

	IEnumerator DelayLoadlevel(float seconds)
	{
		yield return new WaitForSeconds(2);
		secondsLeft = seconds;
		do
		{
			yield return new WaitForSeconds(2);
		} while (--secondsLeft > 0);

		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
