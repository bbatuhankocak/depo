using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{

    Vector2 mousePosition;
    Vector2 attackDir;


    
    public float angle;
    
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        stateTimer = .1f;

        player.isAttacking = true;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        attackDir = mousePosition - (Vector2)player.transform.position;
        attackDir.Normalize();


        DetermineAttackDirection();
        
        DetermineLastDirection();




    }


    public override void Update()
    {
        base.Update();

        player.anim.SetFloat("Horizontal", attackDir.x);
        player.anim.SetFloat("Vertical", attackDir.y);

        
        

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
            player.isAttacking = false;
        }


        if (stateTimer < 0)
            player.SetZeroVelocity();

        

    }

    private void DetermineAttackDirection()
    {
        
        float angle = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg;

        
        if (angle < -180f) angle += 360f;
        else if (angle > 180f) angle -= 360f;
        

        if (angle > 135f || angle < -135f)
        {
            player.sr.flipX = true;
        }
        else
        {
            player.sr.flipX = false;
        }
        
    }

    private void DetermineLastDirection()
    {
        
        float angle = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360f;

        if (angle >= 45f && angle < 135f)
        {
            player.lastDirection = Vector2.up;
        }
        else if (angle >= 135f && angle < 225f)
        {
            player.lastDirection = Vector2.left;
        }
        else if (angle >= 225f && angle < 315f)
        {
            player.lastDirection = Vector2.down;
        }
        else
        {
            player.lastDirection = Vector2.right;
        }

        player.anim.SetFloat("lastMoveX", player.lastDirection.x);
        player.anim.SetFloat("lastMoveY", player.lastDirection.y);
       
    }



    public override void Exit()
    {
        base.Exit();

        
        
    }
}
