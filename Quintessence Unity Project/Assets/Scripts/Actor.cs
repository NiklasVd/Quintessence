using UnityEngine;
using System.Collections;
using System;

public class Actor : Entity
{
    public ActorTeam team;
    public ActorController controller;
    public Attributes attributes;

    public void Heal(int amount)
    {
        var updatedHealth = attributes[AttributeType.CurrentHealth] + amount;
        attributes[AttributeType.CurrentHealth] = Mathf.Max(updatedHealth, 0);
    }
    public void DealDamage(Actor target, DamageType type, int amount)
    {
        target.ReceiveDamage(this, type, amount);
    }

    private void ReceiveDamage(Actor damageDealer, DamageType type, int amount)
    {
        var calculatedAmount = amount;
        var updatedHealth = attributes[AttributeType.CurrentHealth] - calculatedAmount;

        attributes[AttributeType.CurrentHealth] = Mathf.Max(updatedHealth, 0);
    }
}

[Serializable]
public enum ActorTeam
{
    Intruder,
    Mercenary
}

public enum DamageType
{
    Physical,
    Ethereal,
    Pure
}
