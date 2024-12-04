using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class Spawn_obs : MonoBehaviour
{
    [SerializeField] private GameObject porto;
    private Vector3 posporto;
	
	private bool IsRun = false;
	[SerializeField] private float delai;
    [SerializeField] private float yporto;
	private GameObject[] portoexiste;
	private float portovit;
	private float porto_speed = 3f;
	private int i = 1;

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

		if (Input.GetMouseButton(1)|| Input.GetKey("left shift"))
			{
				IsRun = true;

			}

			if (Input.GetMouseButtonUp(1)|| Input.GetKeyUp("left shift"))
			{
				IsRun = false;
			}

		if (IsRun == true && delai >= 1f)
		{
			delai -= 1f * Time.deltaTime;
			
		}

		if (IsRun == true && porto_speed <= 20f)
		{
			
				porto_speed += 2f * Time.deltaTime;
			
		}

		if (IsRun == false && delai <= 2f)
		{
			delai += 1f * Time.deltaTime;
		}

		if (IsRun == false && porto_speed >= 3f)
		{

				porto_speed -= 2f * Time.deltaTime;
			
		}




		portoexiste = GameObject.FindGameObjectsWithTag("portal");

		foreach (var portoexistes in portoexiste)
		{
			portoexistes.GetComponent<Move_porto>().speed_porto = porto_speed;
			
		}

		
		

	}



    IEnumerator Spawner()
    {
        for (; ; )
        {

			if (GameObject.FindGameObjectWithTag("Player").GetComponent<WaffleControl>().mort == false)
			{
				var newObject = (GameObject)Instantiate(porto, posporto, Quaternion.identity, transform);

				newObject.name = i.ToString();
				GameObject.Find(i + "/Haut").name = i.ToString();
				GameObject.Find(i + "/Bas").name = i.ToString();

				i++;
				
			}
			yield return new WaitForSeconds(delai);

			// execute block of code here

		}
    }

}
