using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn_obs : MonoBehaviour
{
    [SerializeField] private GameObject porto;
    private Vector3 posporto;
    [SerializeField] private float yporto;

    // Start is called before the first frame update
    void Start()
    {
        posporto = transform.position + new Vector3(0, yporto, 0);        
        StartCoroutine("Spawner");
        

    }

    // Update is called once per frame
    void Update()
    {
        yporto = UnityEngine.Random.Range(yporto-1, yporto+1);
        if (yporto >= 3)
        {
            yporto = UnityEngine.Random.Range(yporto - 2, yporto - 0.1f);
        }
        else if (yporto <= -3)
        {
            yporto = UnityEngine.Random.Range(yporto + 2, yporto + 0.1f);
        }
        posporto = transform.position + new Vector3(0, yporto, 0);
    }

    IEnumerator Spawner()
    {
        for (; ; )
        {
            // execute block of code here
            Instantiate(porto, posporto, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

}
