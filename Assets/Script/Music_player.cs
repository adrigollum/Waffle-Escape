using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_player : MonoBehaviour
{

	private AudioSource music;

	// Start is called before the first frame update
	void Start()
    {
		music = GetComponent<AudioSource>();
		music.Play();
		Debug.Log("je joue");
	}

    // Update is called once per frame
    void Update()
    {
		
	}
}
