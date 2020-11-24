using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackCard", menuName = "CardData/AttackCard")]
public class AttackCardData : ScriptableObject
{
    [SerializeField] string _name = "...";
    public string Name => _name;

    [SerializeField] int _damage = 1;
    public int Damage => _damage;

    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] int _lifespan = 1;
    public int Lifespan => _lifespan;

    [SerializeField] float _attackFrequency = 1;
    public float AttackFrequency => _attackFrequency;

    [SerializeField] AudioClip _soundEffect = null;
    public AudioClip SoundEffect => _soundEffect;
}
