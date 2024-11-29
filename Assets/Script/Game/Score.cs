using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI texte;
	public static int score;

    // Start is called before the first frame update
    void Start()
    {
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
		
		texte.text = score.ToString();
	}
}
