using UnityEngine;
using System;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] bool isNPC;
    public  SpriteRenderer spriteRenderer {get; private set;}
    public Animator anim {get; private set;}

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //Métodos para serem usados para mudar a animação de personagens durante cutscenes
    //Devem ser usados como eventos em um animation clip ou chamados por código

    public void Idle_Left()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", -1);
        spriteRenderer.flipX = true;

    }

    public void Idle_Right()
    {
        anim.SetFloat("Velocity", 0);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", 1);

        if (isNPC)
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

        if (isNPC)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Walk_Right()
    {
        anim.SetFloat("Velocity", 1);
        anim.SetFloat("Vel_Y", 0);
        anim.SetFloat("Vel_X", 1);

        if (isNPC)
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

    public void PlayByName(string animationName)
    {
        anim.Play(animationName);
    }

    public void ChangePlayerParameter<T>(string parameterName, T value)
    {
        TypeCode paramType = Type.GetTypeCode(value.GetType());
        switch(paramType)
        {
            case TypeCode.Boolean:
                anim.SetBool(parameterName, Convert.ToBoolean(value));
                break;
        }
    }

    public void FlipX(bool flip)
    {
        spriteRenderer.flipX = flip;
    }

    public void TurnOffSelf()
    {
        gameObject.SetActive(false);
    }
}
