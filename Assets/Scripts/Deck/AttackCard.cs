using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public int Damage { get; private set; }
    public int Lifespan { get; private set; }
    public float AttackFrequency { get; private set; }
    public Sprite Graphic { get; private set; }

    public AttackCard(AttackCardData Data)
    {
        Name = Data.Name;
        Damage = Data.Damage;
        Lifespan = Data.Lifespan;
        AttackFrequency = Data.AttackFrequency;
        Graphic = Data.Graphic;
    }

    public override void Use(IDamageable target)
    {
        target.TakeDamage(Damage);
        Lifespan--;
    }

    public bool HasLifeRemaining()
    {
        if (Lifespan <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
