using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    AttackCard _activeCard;
    [SerializeField] Enemy _target = null;
    [SerializeField] SpriteRenderer _spriteRenderer = null;

    public void SetCard(Card card)
    {
        if (card is AttackCard)
        {
            if (_activeCard == null)
            {
                _activeCard = card as AttackCard;
                //Debug.LogWarning(_activeCard.Graphic);
                _spriteRenderer.sprite = _activeCard.Graphic;
                Debug.Log("Card set: " + card.Name);
                StartCoroutine("UseCard");
            }
            else
            {
                Debug.LogWarning("There is already a card set!");
            }
        }
        else
        {
            Debug.LogWarning("This is not an attack card!");
        }
    }

    IEnumerator UseCard()
    {
        while (_activeCard.HasLifeRemaining() && _target.IsAlive)
        {
            _activeCard.Use(_target);
            Debug.Log(_activeCard.Name + " attacked, dealing " + _activeCard.Damage + " damage!");
            yield return new WaitForSeconds(_activeCard.AttackFrequency);
        }
        ClearCard();
    }

    private void ClearCard()
    {
        Debug.Log(_activeCard.Name + " is out!");
        _activeCard = null;
        _spriteRenderer.sprite = null;
    }
}
