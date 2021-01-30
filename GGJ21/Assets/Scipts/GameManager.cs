using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptCharacters;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Characters> characters;
    List<Characters> comeBackCharacters;
    Characters[] resetCharacters;
    [SerializeField] InventoryElement[] inventory;
    [SerializeField] GameObject Inventory;
    GameObject firstItem, secondItem, thirdItem;
    Characters currentCharacter;
    int characterIndex = 0;
    bool selectItem, comeBack;
    GameObject canvas;

    Sprite takeItemSprite, addItemSprite;
    GameObject addItemObject, takeItemObject;
    // Start is called before the first frame update
    void Start()
    {
        // resetCharacters = characters;
        currentCharacter = characters[characterIndex];
        comeBackCharacters = new List<Characters>();
        AnimateCharacter();
        SetItemPositions();
        canvas = GameObject.Find("Canvas");
        
       
       
    }

    private void SetItemPositions()
    {
        firstItem = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(0).gameObject;
        secondItem = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(1).gameObject;
        thirdItem = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(2).gameObject;

        Sprite[] characterSprites = currentCharacter.characterInventorySprite;

        firstItem.GetComponent<Image>().sprite = characterSprites[0];
        secondItem.GetComponent<Image>().sprite = characterSprites[1];
        thirdItem.GetComponent<Image>().sprite = characterSprites[2];

        string[] itemNames = currentCharacter.characterItemNames;
        firstItem.name = itemNames[0];
        secondItem.name = itemNames[1];
        thirdItem.name = itemNames[2];
        

       
    }

    public void FixCharacterItems()
    {
        Sprite[] newSprites = new Sprite[3];
        string[] newNames = new string[3];

        newSprites[0] = firstItem.GetComponent<Image>().sprite;
        newSprites[1] = secondItem.GetComponent<Image>().sprite;
        newSprites[2] = thirdItem.GetComponent<Image>().sprite;

        newNames[0] = firstItem.name;
        newNames[1] = secondItem.name;
        newNames[2] = thirdItem.name;

        currentCharacter.characterInventorySprite = newSprites;
        currentCharacter.characterItemNames = newNames;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (selectItem)
        {
            Inventory.SetActive(true);
        }
    }

    public void AddItemToCharacter(GameObject addItemObj, Sprite sprite)
    {
        string addItemName, takedItemName;


        addItemObject = addItemObj;
        addItemSprite = sprite;


        addItemName = addItemObject.name;
        takedItemName = takeItemObject.name;

        addItemObject.GetComponent<Image>().sprite = takeItemSprite;
        takeItemObject.GetComponent<Image>().sprite = addItemSprite;

        addItemObject.name = takedItemName;
        takeItemObject.name = addItemName;
    }
    public void TakeItemFromCharacter(GameObject takeItemObj, Sprite sprite)
    {
        takeItemObject = takeItemObj;
        takeItemSprite = sprite;
        //takeItemPos = takeItemObject.GetComponent<RectTransform>();
        print("Taked");
    }

    void NextDay()
    {
        Invoke("CloseCanvas", 6);
        
        
    }

    void OpenCanvas()
    {
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        //NextCharacter();
        ComeBackCharacters();
    }

    private void CloseCanvas()
    {
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        print("Radio");
        Invoke("OpenCanvas", 2);
    }

    void ComeBackCharacters()
    {
        if(comeBackCharacters.Count > 0)
        {
            print("Comeback" + comeBackCharacters.Count);
            foreach(Characters character in comeBackCharacters)
            {
                print(character.name);
                currentCharacter = character;
                SetItemPositions();
                return;
            }
        }
        NextCharacter();
    }

    void NextCharacter()
    {
        characterIndex++;
        currentCharacter = characters[characterIndex];
        SetItemPositions();

    }

    public void DetectStatusOfCharacter()
    {
        bool characterHappy;

        foreach(string itemName in currentCharacter.characterItemNames)
        {
            foreach(string trueItem in currentCharacter.trueItemsToGive)
            {
                if(itemName == trueItem)
                {
                    print("0k");
                    if (comeBackCharacters.Contains(currentCharacter))
                    {
                        comeBackCharacters.Remove(currentCharacter);
                    }
                }
                else if(!comeBackCharacters.Contains(currentCharacter))
                {
                    print("Nein");
                    comeBackCharacters.Add(currentCharacter);
                }
            }
        }
        if ((characterIndex+1)%3 == 0 && characterIndex!= 0)
        {
            print("Over");
            NextDay();
            return;
        }
        NextCharacter();
    }

     void AnimateCharacter()
    {
        selectItem = true;
    }


  
}
