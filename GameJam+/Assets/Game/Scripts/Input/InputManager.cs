using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public PlayerControls playerControls;

    public delegate void JumpPress();
    public event JumpPress OnJumpPress;


    public delegate void AttackPress();
    public event AttackPress OnAttackPress;
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

    private void Start()
    {
        playerControls.Keyboard.Jump.performed += ctx => Jump_performed(ctx);
        playerControls.Keyboard.Attack.performed += ctx => Attack_performed(ctx);
    }

    public Vector2 GetMoveVector()
    {
        return playerControls.Keyboard.Move.ReadValue<Vector2>();
    } 

    private void Jump_performed(InputAction.CallbackContext context)
    {
        if (OnJumpPress != null)
        {
            OnJumpPress();
        }
    }
    private void Attack_performed(InputAction.CallbackContext context)
    {
        if (OnAttackPress != null)
        {
            OnAttackPress();
        }
    }
}
