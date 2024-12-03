using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MenuVideoManager : MonoBehaviour
{
    public VideoPlayer introVideo; //puz
    public VideoPlayer menuVideo; 
    public VideoPlayer transitionVideo; 

    private bool isTransitioning = false; 
    private string nextScene; 
    void Start()
{
    
    introVideo.Play();
    introVideo.loopPointReached += EndIntroVideo; 
}

 void EndIntroVideo(VideoPlayer vp)
{
   
    ShowMenu();
}

void ShowMenu()
{
    
    menuVideo.Play();
}

public void OnButtonClick(string action)
{
 
    menuVideo.Stop(); 
    transitionVideo.Play(); 

 
    if (action == "PlayGame")
    {
        transitionVideo.loopPointReached += PlayGame; 
    }
    else if (action == "PlayCredits")
    {
        transitionVideo.loopPointReached += PlayCredits;
}
}
void PlayGame(VideoPlayer vp)
{
    SceneManager.LoadScene("Test");
}

void PlayCredits(VideoPlayer vp)
{
    SceneManager.LoadScene("Credits");
} 
}