using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverText;

    [SerializeField]
    private RemoteTrigger trigger;

    private void Awake()
    {
        trigger.OnTriggered += () => GameOverText.SetActive(true);
    }
}
