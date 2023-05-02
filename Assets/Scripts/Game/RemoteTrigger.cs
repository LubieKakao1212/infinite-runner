using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteTrigger : MonoBehaviour
{
    public event Action OnTriggered;

    [SerializeField]
    private List<string> acceptedTags;

    [SerializeField]
    private bool destroyOnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled && acceptedTags.Contains(collision.tag))
        {
            OnTriggered?.Invoke();
            if (destroyOnTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
