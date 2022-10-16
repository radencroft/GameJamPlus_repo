using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }
    private Vector2 dir;
    private float timer;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        player.currState = "Dash";
        player.inputManager.OnJumpPress += Jump;
        player.inputManager.OnAttackPress += Attack;
        dir = player.inputManager.GetMoveVector();
        timer = player.dashTime;
    }

    public override void OnStateFixedUpdate()
    {
        base.OnStateFixedUpdate();  
        player.anim.SetFloat("speed", Mathf.Abs(dir.x) + Mathf.Abs(dir.y));
        player.rb.velocity = dir * player.dashSpeed * Time.deltaTime; 
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            stateMachine.ChangeState(new PlayerGroundedState(player, stateMachine));
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.rb.velocity = new Vector2(player.rb.velocity.x, 0f);  // stop player Y movement.
        player.inputManager.OnJumpPress -= Jump;
        player.inputManager.OnAttackPress -= Attack;
    }

    #region FUNCTIONS
    private void Jump()
    {
        if (!player.ceilingDetected)
        {
            stateMachine.ChangeState(new PlayerJumpState(player, stateMachine));
        }
    }
    private void Attack()
    {
        Instantiate(player.bullet, player.firePos.position, player.transform.rotation);
    } 
    #endregion
}
