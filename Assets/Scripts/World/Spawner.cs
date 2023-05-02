using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

public abstract class Spawner : MonoBehaviour
{
    protected WorldSpeedManager World => world;

    [SerializeField]
    protected BucketRandom<float> spawnIntervals;

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
        spawnMachine.Forward(Time.deltaTime * world.WorldSpeed);
    }

    protected abstract void Spawn();

    protected virtual void ResetMachine()
    {
        var interval = spawnIntervals.GetRandom();

        while (interval <= 0)
        {
            Spawn();
            interval = spawnIntervals.GetRandom();
        }

        spawnMachine.Interval = interval;
    }
}
