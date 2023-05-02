using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    public event Action<ActivePowerUp> CurrentPowerUpChanged;

    public Shield Shield => shield;

    [SerializeField]
    private ActivePowerUp currentPowerUp;

    [SerializeField]
    private Player player;

    [SerializeField]
    private WorldSpeedManager world;

    [SerializeField]
    private Shield shield;

    public void SetPowerUp(ActivePowerUp powerUp)
    {
        this.currentPowerUp = powerUp;
        CurrentPowerUpChanged?.Invoke(powerUp);
    }

    private void Start()
    {
        InputManager.PowerUpActivated += ActivatePowerUp;
    }

    private void ActivatePowerUp()
    {
        if (currentPowerUp != null)
        {
            currentPowerUp.Activate(this, player, world);
        }
    }
}
