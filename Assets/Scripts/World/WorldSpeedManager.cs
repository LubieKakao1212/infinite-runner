using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpeedManager : MonoBehaviour
{
    [field: SerializeField]
    public float WorldSpeed { get; private set; }
    
    [field: SerializeField]
    public float DistanceTraveled { get; private set; }

    private void Update()
    {
        DistanceTraveled += WorldSpeed * Time.deltaTime;
    }
}
