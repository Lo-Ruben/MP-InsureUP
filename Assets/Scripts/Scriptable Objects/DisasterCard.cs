using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DisasterCard
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/DisasterCards")]
    public class DisasterCard : ScriptableObject
    {
        public string cardName;

        public int cardCost;
        public string description;
        public Sprite cardImage;
    }

}

