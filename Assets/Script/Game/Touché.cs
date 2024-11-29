using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touché : MonoBehaviour
{


	private GameObject[] Gatexiste;
	private bool touche = false;
	private float secondsLeft ;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Gatexiste = GameObject.FindGameObjectsWithTag("gate");


		foreach (var i in Gatexiste)
		{
			if (i.GetComponent<Pass_portal>().touche == true)
			{
				if (i.transform.parent.name == transform.name)
				{
					touche = true;
				}
				
			}


		}

		if (touche == true)
		{
			if (this.tag == "haut")
			{
				transform.Translate(Vector3.up * 10 * Time.deltaTime);
			}
			else
			{
				transform.Translate(Vector3.up * -10 * Time.deltaTime);
			}

			
		}

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<WaffleControl>().mort == true)
		{
			if (this.tag == "haut" && transform.position.y >=0)
			{
				transform.Translate(Vector3.up * -6.25f * Time.deltaTime);
			}
			else if (this.tag == "bas" && transform.position.y <= 0)
			{
				transform.Translate(Vector3.up * 6.25f * Time.deltaTime);
			}
			
				StartCoroutine(DelayLoadlevel(1));
			
		}


	}

	IEnumerator DelayLoadlevel(float seconds)
	{
		yield return new WaitForSeconds(1);
		secondsLeft = seconds;
		do
		{
			yield return new WaitForSeconds(1);
		} while (--secondsLeft > 0);

		SceneManager.LoadScene("Credits", LoadSceneMode.Single);
	}
}
