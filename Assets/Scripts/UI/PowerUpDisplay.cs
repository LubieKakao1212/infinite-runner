using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private PowerupHandler powerUpHandler;

    private void Start()
    {
        powerUpHandler.CurrentPowerUpChanged += SetInfo;
    }

    private void SetInfo(ActivePowerUp powerup)
    {
        if (powerup == null)
        {
            nameDisplay.text = "";
            icon.color = Color.clear;
            return;
        }
        icon.sprite = powerup.DisplaySprite;
        icon.color = powerup.DisplayTint;
        nameDisplay.text = powerup.DisplayName;
    }
}
