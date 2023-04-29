using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    public static event Action PowerUpActivated;

    public static Vector2 MovementTargetWS => Camera.main.ScreenToWorldPoint(MovementTargetSS);
    public static Vector2 MovementTargetSS => instance.input.Player.MoveTarget.ReadValue<Vector2>();

    private static InputManager instance;
    private PlayerInput input;

    void Awake() 
    { 
        Assert.IsNull(instance, $"Duplicate {nameof(InputManager)} on {this} and {instance}");
        instance = this;

        input = new PlayerInput();

        input.Player.UsePowerup.started += (_) => PowerUpActivated?.Invoke();

        input.Enable();
    }

    private void OnDestroy()
    {
        input.Dispose();
    }
}
