using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Référence à votre AudioSource
    public AudioClip audioClip; // Référence à votre AudioClip

    void Start()
    {
        // Assurez-vous que l'AudioSource a le bon clip audio
        audioSource.clip = audioClip;

        // Précharger l'audio (Unity gère cela automatiquement, mais vous pouvez le faire manuellement si nécessaire)
        audioSource.Play(); // Joue le son
    }

    void Update()
    {
        // Vous pouvez ajouter des contrôles pour jouer ou arrêter l'audio ici
        if (Input.GetKeyDown(KeyCode.Space)) // Par exemple, jouer l'audio quand la barre d'espace est pressée
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}