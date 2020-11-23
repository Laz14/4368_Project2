using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] List<AttackCardData> _attackDeckConfig = new List<AttackCardData>();
    [SerializeField] List<CardSpot> _cardSpots = new List<CardSpot>();

    Deck<Card> _deck = new Deck<Card>();
    Card _selectedCard = null;

    private void Awake()
    {
        SetupAbilityDeck();
        _selectedCard = _deck.Draw();
    }

    private void Start()
    {
        StartCoroutine("MainRoutine");
    }

    IEnumerator MainRoutine()
    {
        //Debug.Log("Started enemy coroutine");
        while (_selectedCard != null)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            for (int x = 0; x < 5; x++)
            {
                CardSpot cs = _cardSpots[x];
                if (cs.IsValid(_selectedCard, false)) {
                    cs.SetCard(_selectedCard);
                    _selectedCard = _deck.Draw();
                    break;
                }
            }

            //Debug.Log("Enemy!!!!");
        }
    }

    private void SetupAbilityDeck()
    {
        foreach (AttackCardData attackData in _attackDeckConfig)
        {
            AttackCard newAttackCard = new AttackCard(attackData);
            _deck.Add(newAttackCard);
        }

        _deck.Shuffle();
    }
}
