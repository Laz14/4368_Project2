using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    Card _activeCard;

    public void SetCard(Card card)
    {
        if (_activeCard == null)
        {
            _activeCard = card;
            Debug.Log("Card set: " + card.Name);
        }
        else
        {
            Debug.Log("There is already a card set!");
        }
    }
}
