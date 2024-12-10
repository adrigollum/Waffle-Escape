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

    void Start()
    {
        // Désactiver les boutons au début
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

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
        
        // Activer les boutons
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        
        // Jouer l'animation d'apparition
        playButton.GetComponent<Animator>().SetTrigger("Appear");
        creditsButton.GetComponent<Animator>().SetTrigger("Appear");
    }

    public void OnButtonClick(string action)
{
    // Jouer l'animation de disparition
    playButton.GetComponent<Animator>().SetTrigger("Disappear");
    creditsButton.GetComponent<Animator>().SetTrigger("Disappear");

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

    void PlayGame(VideoPlayer vp)
    {
        SceneManager.LoadScene("Test");
    }

    void PlayCredits(VideoPlayer vp)
    {
        SceneManager.LoadScene("Credits");
    } 
}