using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_portal : MonoBehaviour
{

	public bool touche = false ;
	AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {

		audioData = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log(Suit.EnemySpeed);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<WaffleControl>().mort == false)
			{
				touche = true;
				Score.score += 1;
				audioData.Play(0);
				if(Score.score %15 == 0 && Suit.EnemySpeed < 3)
				{
					Suit.EnemySpeed *= 1.2f;
					
				}
			

			}
			
		}
		
	}



}
