using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortal : Player
{
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        audioManager = FindObjectOfType<AudioManager>();

        stateMachine = new PlayerStateMachine();
        PlayerGroundedState groundedState = new PlayerGroundedState(this, stateMachine);
        stateMachine.Initialize(groundedState);

        runningSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravity;
        facingRight = true;
        runningSound.enabled = false;
        health = HP;
    }

    private void FixedUpdate()
    {
        stateMachine.currState.OnStateFixedUpdate();
        Debug.Log(currState);
    }

    private void Update()
    {
        stateMachine.currState.OnStateUpdate();
        CeilingCheck();
        anim.SetFloat("vertical", rb.velocity.y);
        healthUI.text = health.ToString();

        if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) > 0f)
        {
            runningSound.enabled = true;
        }
        else
        {
            runningSound.enabled = false;
        }
    }

    private void LateUpdate()
    {
        stateMachine.currState.OnStateLateUpdate();
    }
}
