using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.attackState);

    }

    public override void Exit()
    {
        base.Exit();
    }

}
