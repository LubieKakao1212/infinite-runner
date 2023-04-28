using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Util;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private const float stopEpsilon = 0.05f;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float stopDistance = 0.2f;

    private Transform trans;

    private void Start()
    {
        trans = transform;
    }

    void FixedUpdate()
    {
        //Temporary player movement, good for now, polishing comes later
        var xDelta = InputManager.MovementTargetWS.x - trans.position.x;
        rigid.velocity = Vector2.right * Mathf.Sign(xDelta) * CalculateSpeed(xDelta);
    }

    private float CalculateSpeed(float xDelta)
    {
        return Mathf.Clamp01(Mathf.Max((Mathf.Abs(xDelta) - stopEpsilon) / stopDistance, 0)) * speed;
    }
}
