using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

public class MovableSpawner : Spawner
{
    [SerializeField]
    private float spawnSpread;

    [SerializeField]
    private BucketRandom<Movable> obstaclePrefabs;

    [SerializeField]
    private Transform despawnAnchor;

    protected override void Start()
    {
        base.Start();
        deltaTime.AddModifier(Utils.Modifiers.NumericModifierType.Mul, () => World.WorldSpeed);
    }

    protected override void Spawn()
    {
        var x = Random.Range(-spawnSpread, spawnSpread);

        var prefab = obstaclePrefabs.GetRandom();

        var obstacle = Instantiate(prefab, new Vector3(x, transform.position.y), Quaternion.identity);

        obstacle.Spawn(World, despawnAnchor.position.y);
    }
}
