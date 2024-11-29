using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MenuVideoManager : MonoBehaviour
{
    public VideoPlayer introVideo; // Référence à la vidéo d'introduction
    public VideoPlayer menuVideo; // Référence à la vidéo de menu
    public VideoPlayer transitionVideo; // Référence à la vidéo de transition

    private bool isTransitioning = false; // Indicateur pour savoir si une transition est en cours
    private string nextScene; // Nom de la scène à charger après la transition

    void Start()
{
    // Démarre la vidéo d'introduction
    introVideo.Play();
    introVideo.loopPointReached += EndIntroVideo; // Événement lorsque la vidéo d'introduction se termine
}

 void EndIntroVideo(VideoPlayer vp)
{
    // Lorsque la vidéo d'introduction se termine, affiche le menu
    ShowMenu();
}

void ShowMenu()
{
    // Démarre la vidéo de menu en boucle
    menuVideo.Play();
}

public void OnButtonClick(string action)
{
    // Lorsque l'utilisateur clique sur un bouton
    menuVideo.Stop(); // Arrête la vidéo de menu
    transitionVideo.Play(); // Joue la vidéo de transition

    // Appelle la méthode appropriée en fonction de l'action
    if (action == "PlayGame")
    {
        transitionVideo.loopPointReached += PlayGame; // Charge la scène de jeu à la fin de la vidéo de transition
    }
    else if (action == "PlayCredits")
    {
        transitionVideo.loopPointReached += PlayCredits; // Charge la scène des crédits à la fin de la vidéo de transition
    }
}

void PlayGame(VideoPlayer vp)
{
    SceneManager.LoadScene("Test");
}

void PlayCredits(VideoPlayer vp)
{
    SceneManager.LoadScene("Credits", LoadSceneMode.Single);
} 
}