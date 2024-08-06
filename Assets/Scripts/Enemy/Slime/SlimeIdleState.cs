using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : EnemyState
{
    private Slime slime;
    public SlimeIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Slime _slime) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.slime = _slime;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
