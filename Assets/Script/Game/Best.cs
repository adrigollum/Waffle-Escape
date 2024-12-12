using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Best : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI texte;
	
	private  int highScore = 0;
	string highScoreKey = "HighScore";

	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		highScore = PlayerPrefs.GetInt(highScoreKey);
		if (Score.score > highScore)
		{
			PlayerPrefs.SetInt(highScoreKey, Score.score);
			PlayerPrefs.Save();
		}
		
		texte.text = highScore.ToString();
	}
}
