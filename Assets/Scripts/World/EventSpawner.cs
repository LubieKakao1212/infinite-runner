using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EventSpawner : Spawner
{
    [SerializeField]
    private BucketRandom<RandomEventHandler> events;

    protected override void Spawn()
    {
        events.GetRandom().ExecuteEvent();
    }
}
