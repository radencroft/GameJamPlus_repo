using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public PlayerControls playerControls; 

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        //Debug.Log("Controls Enabled"); 
    }

    private void OnDisable()
    {
        playerControls.Disable();
        //Debug.Log("Controls Disabled"); 
    } 

    public Vector2 GetMoveVector()
    {
        return playerControls.Keyboard.Move.ReadValue<Vector2>();
    }
}
