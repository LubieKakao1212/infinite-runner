using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(20)]
public class ShieldDisplay : MonoBehaviour
{
    [SerializeField]
    private Shield shield;

    [SerializeField]
    private TextMeshProUGUI count;

    [SerializeField]
    private GameObject root;

    private void Start()
    {
        shield.OnChargeChanged += UpdateDisplay;
        UpdateDisplay(shield.Charges);
    }

    private void UpdateDisplay(int charges)
    {
        if (charges <= 0)
        {
            root.SetActive(false);
            return;
        }
        root.SetActive(true);
        count.text = charges.ToString();
    }
}
