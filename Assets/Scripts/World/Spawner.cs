using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;
using Utils.Modifiers;

public abstract class Spawner : MonoBehaviour
{
    protected WorldSpeedManager World => world;

    [SerializeField]
    protected BucketRandom<float> spawnIntervals;

    [SerializeField]
    private WorldSpeedManager world;

    private AutoTimeMachine spawnMachine;

    protected ModifiableFloat deltaTime { get; private set; }

    protected virtual void Start()
    {
        spawnMachine = new AutoTimeMachine(() =>
        {
            Spawn();
            ResetMachine();
        }, 0);

        deltaTime = new ModifiableFloat(() => Time.deltaTime);

        ResetMachine();
    }

    private void Update()
    {
        spawnMachine.Forward(deltaTime.GetValue());
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
