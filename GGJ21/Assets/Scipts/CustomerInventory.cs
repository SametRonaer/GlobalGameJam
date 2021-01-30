using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerInventory : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    Sprite sprite;

  
    public void TakeInventory()
    {
        sprite = GetComponent<Image>().sprite;
        gameManager.TakeItemFromCharacter(gameObject, sprite);
    }
}
