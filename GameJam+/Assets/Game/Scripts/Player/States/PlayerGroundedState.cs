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
    } 
}
