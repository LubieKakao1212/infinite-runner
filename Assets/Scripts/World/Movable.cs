using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class Movable : MonoBehaviour
{
    private bool IsSpawned => world != null;

    private float spawnDistanceStamp;
    
    private WorldSpeedManager world;

    private float despawnAnchor;
    private float spawnAnchor;

    [SerializeField]
    private float movementSpeed = 1f;

    private void Update()
    {
        var y = CalculateY();

        if (y < despawnAnchor)
        {
            Destroy(gameObject);
            return;
        }
        var pos = transform.position;
        pos.y = y;
        transform.position = pos;
    }

    public float CalculateY()
    {
        var deltaDistance = spawnDistanceStamp - world.DistanceTraveled;
        return spawnAnchor + deltaDistance * movementSpeed;
    }

    public void Spawn(WorldSpeedManager world, float despawnAnchor)
    {
        if (IsSpawned)
        {
            Debug.LogError("Obstacle Already Spawned");
            return;
        }
        this.world = world;
        this.spawnDistanceStamp = world.DistanceTraveled;
        this.despawnAnchor = despawnAnchor;
        this.spawnAnchor = transform.position.y;
    }

}
