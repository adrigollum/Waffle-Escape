using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_portal : MonoBehaviour
{

	public bool touche = false ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<WaffleControl>().mort == false)
			{
				touche = true;
				Score.score += 1;
			}
			
		}
		
	}



}
