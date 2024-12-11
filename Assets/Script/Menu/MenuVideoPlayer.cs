using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuVideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer introVideo; 
    [SerializeField] private VideoPlayer menuVideo; 
    [SerializeField] private VideoPlayer transitionVideo; 
    [SerializeField] private Button playButton; // Référence au bouton Play
    [SerializeField] private Button creditsButton; // Référence au bouton Credits
    [SerializeField] private Button commandsButton; // Référence au bouton Commandes
    [SerializeField] private GameObject commandsImage; // Référence à l'image des commandes

    void Start()
    {
        // Désactiver les boutons au début
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        commandsButton.gameObject.SetActive(false); // Désactiver le bouton Commandes

        // Désactiver l'image des commandes
        commandsImage.SetActive(false);

        introVideo.Play();
        introVideo.loopPointReached += EndIntroVideo; 
    }

     void Update()
    {
        // Si l'image des commandes est désactivée, rétablir l'interactivité des boutons
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
        
        // Activer les boutons
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        commandsButton.gameObject.SetActive(true); 
        
        // Jouer l'animation d'apparition
        playButton.GetComponent<Animator>().SetTrigger("Appear");
        creditsButton.GetComponent<Animator>().SetTrigger("Appear");
        commandsButton.GetComponent<Animator>().SetTrigger("Appear"); 
    }

    public void OnButtonClick(string action)
    {
        // Jouer l'animation de disparition
        playButton.GetComponent<Animator>().SetTrigger("Disappear");
        creditsButton.GetComponent<Animator>().SetTrigger("Disappear");
        commandsButton.GetComponent<Animator>().SetTrigger("Disappear"); 

        // Arrêter la vidéo et jouer la transition
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
        // Afficher ou masquer l'image des commandes
        commandsImage.SetActive(!commandsImage.activeSelf);

        // Désactiver ou réactiver l'interactivité des boutons
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