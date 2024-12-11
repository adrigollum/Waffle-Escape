using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touché : MonoBehaviour
{


	private GameObject[] Gatexiste;
	private bool touche = false;
	private float secondsLeft ;
 	private GameObject player;

	private Animator animator;
	// Start is called before the first frame update
	void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player"); 
		 animator = player.GetComponent<Animator>();
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
				transform.Translate(Vector3.up * -10 * Time.deltaTime);
			}
			else
			{
				transform.Translate(Vector3.up * -10 * Time.deltaTime);
			}

			
		}

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<WaffleControl>().mort == true) 
		{
			// Désactiver les scripts WaffleControl et WaffleRun
            WaffleControl waffleControl = player.GetComponent<WaffleControl>();
            Waffle_Run waffleRun = player.GetComponent<Waffle_Run>();

            if (waffleControl != null)
            {
                waffleControl.enabled = false; // Désactive le script WaffleControl
            }

            if (waffleRun != null)
            {
                waffleRun.enabled = false; // Désactive le script WaffleRun
            }
			animator.enabled = true;
			player.GetComponent<Animator>().SetTrigger("Dead");
			if (this.tag == "haut" && transform.position.y >=6.25)
			{
				transform.Translate(Vector3.up * 6.25f * Time.deltaTime);
			}
			else if (this.tag == "bas" && transform.position.y <= -2.75)
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

		SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
	}
}
