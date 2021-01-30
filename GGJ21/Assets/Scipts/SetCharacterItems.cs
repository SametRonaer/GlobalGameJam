using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterItems : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField] VideoPlay videoPlay;

    private void Start()
    {
        
    }

    public void FixCharacterItems()
    {
        gameManager.FixCharacterItems();
        gameManager.DetectStatusOfCharacter();
        videoPlay.NextVideo();
        foreach(Transform t in gameObject.transform.parent)
        {
            if(t.tag != "Video")
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
