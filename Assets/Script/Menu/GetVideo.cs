using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GetVideo : MonoBehaviour
{
    [SerializeField] string videoFileName; 

    // Start is called before the first frame update
    void Start()
    {
        GetVideoURL();
    }

    void GetVideoURL() 
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath); 
            videoPlayer.url = videoPath; 
            videoPlayer.Play();
        }
    }
}