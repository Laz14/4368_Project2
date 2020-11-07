using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardSpot : MonoBehaviour
{
    List<Card> _cards = new List<Card>();

    public void AddCard(Card card)
    {
        _cards.Add(card);
        Debug.Log(card.Name + " discarded!");
    }
}
