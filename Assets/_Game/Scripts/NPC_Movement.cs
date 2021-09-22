using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Vector2 distNpc;
    private Vector2 startPos;
    private Vector2 finalPos;
    private Transform _transform;
    private Rigidbody2D myRb2d;
    private Animator anim;

    void Start()
    {
        _transform = GetComponent<Transform>();
        myRb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startPos = _transform.position;
        StartCoroutine(WalkNpc());

    }

    void FixedUpdate()
    {
        anim.SetFloat("Velocity", myRb2d.velocity.magnitude);

        if (myRb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", myRb2d.velocity.x);
            anim.SetFloat("Vel_Y", myRb2d.velocity.y);
        }

        if (Vector2.Distance(finalPos, _transform.position) <= 0.1f || Vector2.Distance(Globals.Player.transform.position, _transform.position) <= 1.0f)
        {
            myRb2d.velocity = Vector2.zero;
        }
    }

     private IEnumerator WalkNpc()
    {
        while(true)
        {
            if ((int)Random.Range(0f, 1.9999f) == 0)
            {
                //Move o npc em x

                finalPos = new Vector2(GetPosition('x'), _transform.position.y);
                myRb2d.velocity = new Vector2(Mathf.Sign( finalPos.x - _transform.position.x) * velocity, 0f);
            }
            else
            {
                //Move o npc em y

                finalPos = new Vector2(_transform.position.x, GetPosition('y'));
                myRb2d.velocity = new Vector2(0f, Mathf.Sign(finalPos.y - _transform.position.y) * velocity);
            }

            yield return (new WaitForSeconds(Random.Range(5f, 10f)));
        }
        
    }

    private float GetPosition(char axis)
    {
        float random = Random.Range(0f, 1f);

        switch (axis)
        {
            case 'x':
                return ((startPos.x + distNpc.x) - (startPos.x - distNpc.x)) * random + (startPos.x - distNpc.x);
            case 'y':
                return ((startPos.y + distNpc.y) - (startPos.y - distNpc.y)) * random + (startPos.y - distNpc.y);
            default:
                return 0f;
        }
    }

    public void SetAnimationParams()
    {
        
    }
}
