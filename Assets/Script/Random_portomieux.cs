using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_portomieux : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;
    private GameObject couvert;

    // Start is called before the first frame update
    void Start()
    {
        couvert = Obstacles[UnityEngine.Random.Range(0, Obstacles.Length)];		
        Instantiate(couvert, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
