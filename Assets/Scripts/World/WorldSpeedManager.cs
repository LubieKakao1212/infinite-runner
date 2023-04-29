using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Modifiers;

public class WorldSpeedManager : MonoBehaviour
{
    public ModifiableFloat SpeedUpFactor { get; private set; }

    [field: SerializeField]
    public float WorldSpeed { get; private set; }
    
    [field: SerializeField]
    public float DistanceTraveled { get; private set; }

    [SerializeField]
    private float SpeedUpAmount;

    private void Start()
    {
        SpeedUpFactor = new ModifiableFloat(SpeedUpAmount);
    }

    private void Update()
    {
        DistanceTraveled += WorldSpeed * Time.deltaTime;

        WorldSpeed += SpeedUpFactor.GetValue() * Time.deltaTime;
    }
}
