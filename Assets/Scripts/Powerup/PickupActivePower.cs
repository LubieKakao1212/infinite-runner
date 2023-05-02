using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupActivePower : PickupPower
{
    [SerializeField]
    private ActivePowerUp powerup;

    protected override void OnPickup(PowerupHandler activeHandler)
    {
        activeHandler.SetPowerUp(powerup);
    }
}
