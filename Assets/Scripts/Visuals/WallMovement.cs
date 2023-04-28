using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public static readonly int distanceId = Shader.PropertyToID("_Distance");

    [SerializeField]
    private SpriteRenderer rend;

    [SerializeField]
    private WorldSpeedManager world;

    private MaterialPropertyBlock props;

    private void Start()
    {
        props = new MaterialPropertyBlock();
        rend.SetPropertyBlock(props);
    }

    private void Update()
    {
        props.SetFloat(distanceId, world.DistanceTraveled);
        rend.SetPropertyBlock(props);
    }
}
