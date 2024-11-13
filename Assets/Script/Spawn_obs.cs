using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn_obs : MonoBehaviour
{
    [SerializeField] private GameObject toyo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawner");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        for (; ; )
        {
            // execute block of code here
            Instantiate(toyo);
            yield return new WaitForSeconds(1f);
        }
    }

}
