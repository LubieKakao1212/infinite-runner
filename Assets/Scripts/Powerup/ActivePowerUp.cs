using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivePowerUp : ScriptableObject
{
    [field: SerializeField]
    public Sprite DisplaySprite { get; private set; }

    [field: SerializeField]
    public Color DisplayTint { get; private set; }

    [field: SerializeField]
    public string DisplayName { get; private set; }

    public abstract void Activate(ActivePowerupHandler handler, Player plyaer, WorldSpeedManager world);
}
