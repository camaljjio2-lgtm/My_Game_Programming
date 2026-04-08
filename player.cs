using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 inputvec;
    SpriteRenderer sprite;
    public float speed;
    bool ismove = false;

    Animator anim;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (!ismove) inputvec.x = Input.GetAxisRaw("Horizontal");
       
 
        if (Input.GetKeyDown(KeyCode.Space) && !ismove)
        {
            anim.SetTrigger("attack");
            
            ismove = true;
        }
        if(inputvec.x != 0)
        {
            sprite.flipX = inputvec.x > 0;
        }
    }
    public void attacks()
    {
        ismove = false;
    }

    void FixedUpdate() {
        if(!ismove)
        {
            Vector2 move = inputvec.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }

    }

    void LateUpdate()
    {
        anim.SetBool("ismove", inputvec.x!=0);

    }
}
