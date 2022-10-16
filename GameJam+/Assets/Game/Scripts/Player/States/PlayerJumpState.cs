using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }
    private float jumpHeight, jumpMin;
    private bool jumpUP, jumpDOWN;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        player.currState = "Jumping";

        player.anim.SetBool("jumping",true);
        jumpMin = player.transform.position.y;
        jumpHeight = player.transform.position.y + player.jumpHeight;
        jumpUP = true;
        jumpDOWN = false;
        player.inputManager.OnAttackPress += Attack;
    }


    public override void OnStateFixedUpdate()
    {
        base.OnStateFixedUpdate();
        if (jumpUP)
        {
            if (player.transform.position.y <= jumpHeight)
            {
                player.transform.position = player.transform.position + new Vector3(0, Time.deltaTime * player.jumpSpeedUP, 0);
            }
            else
            {
                jumpUP = false;
                jumpDOWN = true;
            }

            // alternative exit if theres a ceiling.
            if (player.ceilingDetected)
            {
                jumpUP = false;
                jumpDOWN = true;
            }
        }

        if (jumpDOWN)
        {
            if (player.transform.position.y > jumpMin)
            {
                player.transform.position = player.transform.position - new Vector3(0, Time.deltaTime * player.jumpSpeedDOWN, 0);
            }
            else
            {
                stateMachine.ChangeState(new PlayerGroundedState(player, stateMachine));
            }
        } 
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.anim.SetBool("jumping", false); 
        player.inputManager.OnAttackPress -= Attack;
    }
    private void Attack()
    {
        Instantiate(player.bullet, player.firePos.position, player.transform.rotation);
    }
}
