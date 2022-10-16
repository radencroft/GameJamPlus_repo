using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        player.currState = "Grounded";
        player.inputManager.OnJumpPress += Jump;
        player.inputManager.OnAttackPress += Attack;
        player.inputManager.OnDashPress += Dash;
    }

    public override void OnStateFixedUpdate()
    {
        base.OnStateFixedUpdate();
        player.GenericMove();
        player.GenericFlip();
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate(); 
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
        if(!player.ceilingDetected)
        {
            stateMachine.ChangeState(new PlayerJumpState(player, stateMachine));
        }
    }
    private void Attack()
    { 
        Instantiate(player.bullet, player.firePos.position, player.transform.rotation);
    }
    private void Dash()
    {
        stateMachine.ChangeState(new PlayerDashState(player, stateMachine));
    }
    #endregion
}
