using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currState { get; private set; }

    public void Initialize(PlayerState startState)
    {
        currState = startState;
        currState.OnStateEnter();
    }

    public void ChangeState(PlayerState newState)
    {
        currState.OnStateExit();
        currState = newState;
        currState.OnStateEnter();
    }
}
