using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_credit : MonoBehaviour
{
	
	public int scorec = Score.score;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		GetComponent<TextMeshPro>().text = scorec.ToString();
	}
}
