using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupPower : MonoBehaviour
{
    protected abstract void OnPickup(PowerupHandler activeHandler);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var handler = collision.GetComponent<PowerupHandler>();
        
        if (handler != null)
        {
            OnPickup(handler);
        }

        Destroy(gameObject);
    }
}
