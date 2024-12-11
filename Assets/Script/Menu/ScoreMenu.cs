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
    
    SceneManager.LoadScene("Game");
}

public void PlayCredits()
{
    
    SceneManager.LoadScene("Credits");
}
}
