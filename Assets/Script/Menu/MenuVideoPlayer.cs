using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuVideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer introVideo; 
    [SerializeField] private VideoPlayer menuVideo; 
    [SerializeField] private VideoPlayer transitionVideo; 
    [SerializeField] private Button playButton; 
    [SerializeField] private Button creditsButton; 
    [SerializeField] private Button commandsButton; 
    [SerializeField] private GameObject commandsImage; 
    void Start()
    {
        // Désactiver les boutons au début
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        commandsButton.gameObject.SetActive(false); 

        // Désactiver l'image des commandes
        commandsImage.SetActive(false);

        introVideo.Play();
        introVideo.loopPointReached += EndIntroVideo; 
    }

     void Update()
    {
        
        if (!commandsImage.activeSelf)
        {
            playButton.interactable = true;
            creditsButton.interactable = true;
            commandsButton.interactable = true;
        }
    }

    void EndIntroVideo(VideoPlayer vp)
    {
        ShowMenu();
    }

    void ShowMenu()
    {
        menuVideo.Play();
        
        
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        commandsButton.gameObject.SetActive(true); 
        
        
        playButton.GetComponent<Animator>().SetTrigger("Appear");
        creditsButton.GetComponent<Animator>().SetTrigger("Appear");
        commandsButton.GetComponent<Animator>().SetTrigger("Appear"); 
    }

    public void OnButtonClick(string action)
    {
        
        playButton.GetComponent<Animator>().SetTrigger("Disappear");
        creditsButton.GetComponent<Animator>().SetTrigger("Disappear");
        commandsButton.GetComponent<Animator>().SetTrigger("Disappear"); 

        
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

    private void OnCommandsButtonClick()
    {
        
        commandsImage.SetActive(!commandsImage.activeSelf);

        
        bool interactable = !commandsImage.activeSelf;
        playButton.interactable = interactable;
        creditsButton.interactable = interactable;
        commandsButton.interactable = interactable;
    }

    [SerializeField] private void PlayGame(VideoPlayer vp)
    {
        SceneManager.LoadScene("Game");
    }

    [SerializeField] private void PlayCredits(VideoPlayer vp)
    {
        SceneManager.LoadScene("Credits");
    } 
}