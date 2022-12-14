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
        if (player.canFire)
        {
            player.startFireCooldown = true;
            GameObject bullet = Instantiate(player.bullet, player.firePos.position, player.firePos.rotation);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(player.firePos.up * bullet.GetComponent<Bullet>().speed, ForceMode2D.Impulse);
        }
    }
    private void Dash()
    {
        if (player.canDash)
        {
            player.startDashCooldown = true;
            stateMachine.ChangeState(new PlayerDashState(player, stateMachine));
        }
    }
    #endregion
}
