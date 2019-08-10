using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int lives = 5;   
    [SerializeField]
    private float speed = 3.0F;

    private CharState state
    {
        get { return (CharState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int) value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        state = CharState.idle;

        if (Input.GetButton("Horizontal")) Run();        
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        state = CharState.run;
    }
}

public enum CharState
{
    idle,
    run
}