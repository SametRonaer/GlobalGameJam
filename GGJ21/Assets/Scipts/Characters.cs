namespace ScriptableCharacters
{

    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    [CreateAssetMenu(fileName = "Character", menuName = "Character/New Character", order = 0)]
    public class Characters : ScriptableObject
    {
        public Sprite[] characterInventorySprite;
        public string[] characterItemNames;
        public int successRep;
        public int killRep;
        public int comeBackAmount;
        public string[] trueItemsToGive;
        public int[] trueItemsRep;
        public string[] characterStory;



    }
}
