using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpot : MonoBehaviour
{
    [SerializeField] AudioClip _soundEffect = null;

    AttackCard _activeCard;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    public void SetCard(Card card)
    {
        _activeCard = card as AttackCard;
        _spriteRenderer.sprite = _activeCard.Graphic;
        //_audioSource.PlayOneShot(_soundEffect);
    }
}
