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

    public string[] videoFileName; 

    private bool isBestscoreAppearing = false;

    void Start()
    {
        // Désactiver les boutons au début
        introVideo.enabled = true;
        introVideo.gameObject.SetActive(true);
        menuVideo.enabled = false;
        menuVideo.gameObject.SetActive(false);
        transitionVideo.enabled = false;
        transitionVideo.gameObject.SetActive(false);
        
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        commandsButton.gameObject.SetActive(false); 
        
        // Désactiver l'image des commandes
        commandsImage.SetActive(false);

        videoFileName[0] = "EnterMenu.mp4"; 
        videoFileName[1] = "menu.mp4"; 
        videoFileName[2] = "ExitMenu.mp4"; 

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
        introVideo.Stop();
        introVideo.enabled = false;
        introVideo.gameObject.SetActive(false);
        menuVideo.enabled = true;
        menuVideo.gameObject.SetActive(true);
        ShowMenu();
    }

    void ShowMenu()
{

    string videoPath1 = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName[1]);
    Debug.Log($"Menu video path: {videoPath1}");

    
    menuVideo.url = videoPath1;
    menuVideo.url = videoPath1;
    menuVideo.Prepare(); // Prépare la vidéo
    menuVideo.prepareCompleted += (source) => 
    menuVideo.Play();
    
    // Boutons et animations
    playButton.gameObject.SetActive(true);
    creditsButton.gameObject.SetActive(true);
    commandsButton.gameObject.SetActive(true); 
    Bestscore.SetActive(true);

    playButton.GetComponent<Animator>().SetTrigger("Appear");
    creditsButton.GetComponent<Animator>().SetTrigger("Appear");
    commandsButton.GetComponent<Animator>().SetTrigger("Appear");
    Bestscore.GetComponent<Animator>().SetBool("IsAppearing", true);
    isBestscoreAppearing = true;

    Bestscore.GetComponent<Animator>().SetBool("IsTinting", true);
}

    public void OnButtonClick(string action)
    {
        playButton.GetComponent<Animator>().SetTrigger("Disappear");
        creditsButton.GetComponent<Animator>().SetTrigger("Disappear");
        commandsButton.GetComponent<Animator>().SetTrigger("Disappear"); 
        Bestscore.GetComponent<Animator>().SetTrigger("Disappear");
        menuVideo.Stop();
        menuVideo.enabled = false;
        menuVideo.gameObject.SetActive(false);
        transitionVideo.enabled = true;
        transitionVideo.gameObject.SetActive(true);
        if(transitionVideo) 
        {
        string videoPath2 = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName[2]);
        Debug.Log(videoPath2);
        transitionVideo.url = videoPath2;
        transitionVideo.Prepare(); // Prépare la vidéo
        transitionVideo.prepareCompleted += (source) => 
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
