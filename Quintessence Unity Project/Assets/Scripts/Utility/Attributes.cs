using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Attributes
{
    public int initialMaxHealth, initialMaxStamina;
    private Dictionary<AttributeType, int> attributeItems;

    public int this[AttributeType type]
    {
        get { return attributeItems[type]; }
        set { attributeItems[type] = value; }
    }

    public void Initialize()
    {
        attributeItems = new Dictionary<AttributeType, int>(4);

        attributeItems.Add(AttributeType.CurrentHealth, initialMaxHealth);
        attributeItems.Add(AttributeType.MaxHealth, initialMaxHealth);
        attributeItems.Add(AttributeType.CurrentStamina, initialMaxStamina);
        attributeItems.Add(AttributeType.MaxStamina, initialMaxStamina);
    }
}

public enum AttributeType
{
    CurrentHealth,
    MaxHealth,

    CurrentStamina,
    MaxStamina
}
