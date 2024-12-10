using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{

    void Start()
    {
       
    }
   
  public void PlayGame()
{
    Debug.Log("PlayGame clicked");
    SceneManager.LoadScene("Test");
}

public void PlayCredits()
{
    Debug.Log("PlayCredits clicked");
    SceneManager.LoadScene("Credits");
}
}
