using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    float videoTime;
    [SerializeField] VideoClip[] videos;
    [SerializeField] VideoPlayer videoPlayer;
    int videoIndex = 1;
    bool nextVideo = true;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitVideo", 6.3f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void WaitVideo()
    {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
                
            }

        
    }

    public void NextVideo()
    {
        videoPlayer.clip = videos[videoIndex];
        //Invoke("WaitVideo", 12.5f);
        WaitVideo();
        if(videoIndex%2 == 1)
        {
            Invoke("NextVideo", 6.3f) ;
        }
        
        videoIndex++;
        
        
    }
}
