using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyStateMachine stateMachine { get; private set; }

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;


    protected virtual void Awake()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }
}


