using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touché : MonoBehaviour
{


	private GameObject[] Gatexiste;
	private bool touche = false;
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
	}
}
