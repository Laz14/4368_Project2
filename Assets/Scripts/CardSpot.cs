using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    AttackCard _activeCard;
    [SerializeField] Player _target = null;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] bool _isPlayerSide;
    AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    public void SetCard(Card card)
    {
        _activeCard = card as AttackCard;
        //Debug.LogWarning(_activeCard.Graphic);
        _spriteRenderer.sprite = _activeCard.Graphic;
        _audioSource.PlayOneShot(_activeCard.SoundEffect);
        //Debug.Log("Card set: " + card.Name);
        StartCoroutine("UseCard");
    }

    public bool IsValid(Card card, bool isPlayerside)
    {
        if (card is AttackCard && _isPlayerSide == isPlayerside && _activeCard == null)
        {
            return true;
        }
        else
        {
            //Debug.LogWarning("Invalid! Card placement failed!");
            return false;
        }
    }

    IEnumerator UseCard()
    {
        while (_activeCard.HasLifeRemaining() && _target.IsAlive)
        {
            _activeCard.Use(_target);
            //Debug.Log(_activeCard.Name + " attacked, dealing " + _activeCard.Damage + " damage!");
            yield return new WaitForSeconds(_activeCard.AttackFrequency);
        }
        ClearCard();
    }

    private void ClearCard()
    {
        //Debug.Log(_activeCard.Name + " is out!");
        _activeCard = null;
        _spriteRenderer.sprite = null;
    }
}
