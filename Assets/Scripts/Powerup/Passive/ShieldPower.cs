using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : PickupPower
{
    [SerializeField]
    private int chargesAdded;

    protected override void OnPickup(PowerupHandler activeHandler)
    {
        activeHandler.Shield.AddCharges(chargesAdded);
    }
}
