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
    [SerializeField] private GameObject Bestscore;

    [SerializeField] string[] videoFileName; 

    private bool isBestscoreAppearing = false;

    void Start()
    {
        // Désactiver les boutons au début
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        commandsButton.gameObject.SetActive(false); 
        
        // Désactiver l'image des commandes
        commandsImage.SetActive(false);

        if(introVideo) 
        {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName[0]);
        Debug.Log(videoPath);
        introVideo.url = videoPath;
        introVideo.Play();
        introVideo.loopPointReached += EndIntroVideo; 
        }

        
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
        
        string videoPath1 = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName[1]);
        Debug.Log(videoPath1);
        menuVideo.url = videoPath1;
        menuVideo.Play();
        
        
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        commandsButton.gameObject.SetActive(true); 
        Bestscore.SetActive(true);
        
        // Vérifiez si l'animation "Appear" a déjà été jouée pour Bestscore
            playButton.GetComponent<Animator>().SetTrigger("Appear");
            creditsButton.GetComponent<Animator>().SetTrigger("Appear");
            commandsButton.GetComponent<Animator>().SetTrigger("Appear"); 
            Bestscore.GetComponent<Animator>().SetBool("IsAppearing", true);
            isBestscoreAppearing = true;

            // Activer le booléen "IsTinting" après "Appear"
            Bestscore.GetComponent<Animator>().SetBool("IsTinting", true);
        
    }

    public void OnButtonClick(string action)
    {
        playButton.GetComponent<Animator>().SetTrigger("Disappear");
        creditsButton.GetComponent<Animator>().SetTrigger("Disappear");
        commandsButton.GetComponent<Animator>().SetTrigger("Disappear"); 
        Bestscore.GetComponent<Animator>().SetTrigger("Disappear");
        menuVideo.Stop(); 
        if(transitionVideo) 
        {
        string videoPath2 = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName[2]);
        Debug.Log(videoPath2);
        transitionVideo.url = videoPath2;
        transitionVideo.Play();
        } 

        if (action == "PlayGame")
        {
            transitionVideo.loopPointReached += PlayGame; 
        }
        else if (action == "PlayCredits")
        {
            transitionVideo.loopPointReached += PlayCredits;
        }
    }

    public void OnCommandsButtonClick()
    {
        commandsImage.SetActive(!commandsImage.activeSelf);

        // Réinitialiser l'état de Bestscore lorsque le bouton des commandes est cliqué
        if (commandsImage.activeSelf)
        {
            Bestscore.GetComponent<Animator>().SetBool("IsTinting", true);
        }
        else
        {
            Bestscore.GetComponent<Animator>().SetBool("IsAppearing", true);
        }

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
