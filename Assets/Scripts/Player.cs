using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;

    void Update()
    {
        Debug.Log(InputManager.MovementTargetWS);
        rigid.MovePosition(InputManager.MovementTargetWS);
    }
}
