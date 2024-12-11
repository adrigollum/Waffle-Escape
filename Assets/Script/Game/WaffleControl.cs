using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffleControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float jumpSpeed = 5f;
    public bool mort = false;
    AudioSource audioData;

    // Tableau pour stocker les sons
    [SerializeField] private AudioClip[] audioClips; // 0: saut, 1: mort

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!mort && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")))
        {
            Jump();
        }

        
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
        PlayJumpSound();
    }

    private void PlayJumpSound()
    {
        if (audioClips.Length > 0 && audioClips[0] != null)
        {
            audioData.PlayOneShot(audioClips[0]);
        }
    }

    public void PlayDeathSound()
    {
        if (audioClips.Length > 1 && audioClips[1] != null)
        {
            audioData.PlayOneShot(audioClips[1]);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "gate" && mort == false)
        {
            mort = true;
            PlayDeathSound();
        }
    }
}