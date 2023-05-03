using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverText;

    [SerializeField]
    private TextMeshProUGUI distanceTraveledText;

    [SerializeField]
    private RemoteTrigger trigger;
    
    [SerializeField]
    private WorldSpeedManager world;

    private void Awake()
    {
        trigger.OnTriggered += DisplayGameEnd;
    }

    private void DisplayGameEnd()
    {
        GameOverText.SetActive(true);
        distanceTraveledText.text = world.DistanceTraveled.ToString("0");
    }
}
