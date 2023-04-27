using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    public static Vector2 MovementTargetWS => Camera.main.ScreenToWorldPoint(MovementTargetSS);
    public static Vector2 MovementTargetSS => instance.input.Player.MoveTarget.ReadValue<Vector2>();

    private static InputManager instance;
    private PlayerInput input;

    void Awake() 
    { 
        Assert.IsNull(instance, $"Duplicate {nameof(InputManager)} on {this} and {instance}");
        instance = this;

        input = new PlayerInput();
        
        input.Enable();
    }

    private void OnDestroy()
    {
        input.Dispose();
    }
}
