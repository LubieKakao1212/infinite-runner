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
    private float SpawnIntervalMin;

    [SerializeField]
    private float SpawnIntervalMax;

    [SerializeField]
    private List<Obstacle> obstaclePrefabs;

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

        var prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        var obstacle = Instantiate(prefab, new Vector3(x, transform.position.y), Quaternion.identity);

        obstacle.Spawn(world, despawnAnchor.position.y);
    }

    private void ResetMachine()
    {
        spawnMachine.Interval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
    }
}
