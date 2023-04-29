using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnSpread;

    [SerializeField]
    private BucketRandom<float> spawnIntervals;

    [SerializeField]
    private BucketRandom<Obstacle> obstaclePrefabs;

    [SerializeField]
    private Transform despawnAnchor;

    [SerializeField]
    private WorldSpeedManager world;

    private AutoTimeMachine spawnMachine;
    
    void Start()
    {
        spawnMachine = new AutoTimeMachine(() =>
        {
            Spawn();
            ResetMachine();
        }, 0);

        ResetMachine();
    }

    private void Update()
    {
        spawnMachine.Forward(Time.deltaTime);
    }

    private void Spawn()
    {
        var x = Random.Range(-spawnSpread, spawnSpread);

        var prefab = obstaclePrefabs.GetRandom();

        var obstacle = Instantiate(prefab, new Vector3(x, transform.position.y), Quaternion.identity);

        obstacle.Spawn(world, despawnAnchor.position.y);
    }

    private void ResetMachine()
    {
        var interval = spawnIntervals.GetRandom();

        while (interval <= 0)
        {
            Spawn();
            interval = spawnIntervals.GetRandom();
        }

        spawnMachine.Interval = interval / world.WorldSpeed;
    }
}
