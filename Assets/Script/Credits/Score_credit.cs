using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_credit : MonoBehaviour
{
		[SerializeField] TextMeshProUGUI texte;

	

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		texte.text = Score.score.ToString();
	}
}
