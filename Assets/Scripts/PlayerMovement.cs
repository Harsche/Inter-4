using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    private float hor, ver;
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        anim.SetFloat("Velocity", rb2d.velocity.magnitude);
        
    }

    private void FixedUpdate()
    {
        if(ver == 0)
        {
            rb2d.velocity = new Vector2(hor * velocity, 0f);
        }
        else if(hor == 0)
        {
            rb2d.velocity = new Vector2(0f, ver * velocity);
        }

        if(rb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", rb2d.velocity.x);
            anim.SetFloat("Vel_Y", rb2d.velocity.y);
        }


    }
}
