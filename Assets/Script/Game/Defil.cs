using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defil : MonoBehaviour
{
	[SerializeField] private GameObject fond;
	private float vitesse;
	private Renderer rend;
	// Start is called before the first frame update
	void Start()
    {
		rend = fond.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		vitesse = GameObject.FindGameObjectWithTag("portal").GetComponent<Move_porto>().speed_porto/18;
		rend.material.mainTextureOffset = new Vector2(rend.material.mainTextureOffset.x + vitesse * Time.deltaTime, 0);
    }
}
