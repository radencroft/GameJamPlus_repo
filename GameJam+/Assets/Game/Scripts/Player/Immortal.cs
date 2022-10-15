using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortal : Player
{
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        inputManager = InputManager.Instance;

        stateMachine = new PlayerStateMachine();
        PlayerGroundedState groundedState = new PlayerGroundedState(this, stateMachine);
        stateMachine.Initialize(groundedState);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravity;
        facingRight = true; 
    }

    private void FixedUpdate()
    {
        stateMachine.currState.OnStateFixedUpdate(); 
        Debug.Log(currState);
    }

    private void Update()
    {
        stateMachine.currState.OnStateUpdate();
        anim.SetFloat("vertical", rb.velocity.y);
    }

    private void LateUpdate()
    {
        stateMachine.currState.OnStateLateUpdate();
    }
}
