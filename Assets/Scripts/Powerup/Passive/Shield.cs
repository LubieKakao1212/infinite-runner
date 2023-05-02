using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Shield : MonoBehaviour
{
    private int charges;

    [SerializeField]
    private RemoteTrigger playerKillDetector;

    private void Start()
    {
        AddCharges(2);
    }

    public void AddCharges(int amount)
    {
        charges += amount;

        SetEnabled(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (--charges <= 0)
        {
            SetEnabled(false);
        }
    }

    private void SetEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
        if (enabled)
        {
            playerKillDetector.enabled = false;
        }
        else
        {
            playerKillDetector.StartCoroutine(EnableKillDetector());
        }
    }

    private IEnumerator EnableKillDetector()
    {
        yield return null;
        playerKillDetector.enabled = true;
    }
}
