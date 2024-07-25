using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;

    protected Player player;

    protected Rigidbody2D rb;

    public string animBoolName;

    public Vector2 movement;

    protected bool triggerCalled;
    protected float stateTimer;

    
    
    


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = animBoolName;
        
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName,true);
        triggerCalled = false;
        rb = player.rb;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.magnitude > 0 ) 
            movement.Normalize();


        player.anim.SetFloat("Horizontal",movement.x);
        player.anim.SetFloat("Vertical", movement.y);

        
    }

    



    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName,false);

    }



    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
