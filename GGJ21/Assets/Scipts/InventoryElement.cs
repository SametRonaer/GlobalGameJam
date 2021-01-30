using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public int amount;
    [SerializeField] GameObject gameManagerObject;
    GameManager gameManager;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        
    }

  
    public void AddItem()
    {
        sprite = GetComponent<Image>().sprite;
        gameManager.AddItemToCharacter(gameObject, sprite);
        //return gameObject.name;
    }

}
