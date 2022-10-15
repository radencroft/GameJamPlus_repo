using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateFixedUpdate() { }
    public virtual void OnStateUpdate() { }
    public virtual void OnStateLateUpdate() { }
    public virtual void OnStateExit() { }
}
