using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D mv;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 14f;

    private void Start()
    {
        mv = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       dirX = Input.GetAxisRaw("Horizontal");
       mv.velocity = new Vector2(dirX * speed, mv.velocity.y);

       if(Input.GetButtonDown("Jump"))
       {
        mv.velocity = new Vector2(mv.velocity.x, jump);
       } 

       UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
       if(dirX > 0f)
       {
        anim.SetBool("running", true);
        sprite.flipX = false;
       }
       else if(dirX < 0f)
       {
        anim.SetBool("running", true);
        sprite.flipX = true;
       }
       else
       {
        anim.SetBool("running", false);
       }
    }
}
