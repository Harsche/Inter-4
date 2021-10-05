using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] bool isNPC;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Idle_Left()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", -1);

        if(isNPC)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Idle_Right()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", 1);

        if(isNPC)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Idle_Up()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_X", 0);
        anim.SetFloat("Vel_Y", 1);  
    }

    public void Idle_Down()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_X", 0);
        anim.SetFloat("Vel_Y", -1);  
    }

    public void Walk_Left()
    {
        anim.SetFloat("Velocity", 1);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", -1);

        if(isNPC)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Walk_Right()
    {
        anim.SetFloat("Velocity", 1);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", 1);

        if(isNPC)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Walk_Up()
    {
        anim.SetFloat("Velocity", 1);
        anim.SetFloat("Vel_X", 0);
        anim.SetFloat("Vel_Y", 1);  
    }

    public void Walk_Down()
    {
        anim.SetFloat("Velocity", 1);
        anim.SetFloat("Vel_X", 0);
        anim.SetFloat("Vel_Y", -1);  
    }

    public void TurnOffSelf()
    {
        gameObject.SetActive(false);
    }
}
