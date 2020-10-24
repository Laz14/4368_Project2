using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    private void Start()
    {
        SetupAbilityDeck();
    }

    private void SetupAbilityDeck()
    {
        Debug.Log("Creating Ability Cards...");
        AbilityCard cardA = new AbilityCard("Slash");
        _abilityDeck.Add(cardA);
        AbilityCard cardB = new AbilityCard("Kick");
        _abilityDeck.Add(cardB);
        AbilityCard cardC = new AbilityCard("Charge");
        _abilityDeck.Add(cardC);
        AbilityCard cardD = new AbilityCard("Shout");
        _abilityDeck.Add(cardD);

        _abilityDeck.Shuffle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    private void Draw()
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consisder expanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
