using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    
    public float moveSpeed;

    public Animator anim;
    SpriteRenderer sr;
    public Rigidbody2D rb;

    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public float collisionOffset = .05f;

    

    #region States

    public PlayerIdleState idleState {  get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    #endregion


   

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        attackState = new PlayerAttackState(this, stateMachine,"Attack");

    }




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        stateMachine.Initialize(idleState);
    }



    private void Update()
    {
        stateMachine.currentState.Update();

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        

    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();




    void Flip()
    {
        sr.flipX = !sr.flipX;
    }


    private void FlipController()
    {
        if (stateMachine.currentState.movement.x > 0 && sr.flipX)
        {
            Flip();
        }
        else if (stateMachine.currentState.movement.x < 0 && !sr.flipX)
        {
            Flip();
        }

        
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2 (xVelocity, yVelocity);
        FlipController();
    }

    public void SetZeroVelocity()
    {
        rb.velocity = new Vector2 (0,0);
    }
    
}
