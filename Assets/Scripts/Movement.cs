using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private bool player;
    [SerializeField] private bool moveNpc;
    [SerializeField] private Vector2 distNpc;
    private Vector2 startPos;
    private Vector2 finalPos;
    private float hor, ver;
    private Transform _transform;
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        _transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if(moveNpc)
        {
            startPos = _transform.position;
            StartCoroutine(WalkNpc());
        }
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        anim.SetFloat("Velocity", rb2d.velocity.magnitude);
        
    }

    private void FixedUpdate()
    {
        if(player)
        {
            if (ver == 0)
            {
                rb2d.velocity = new Vector2(hor * velocity, 0f);
            }
            else if (hor == 0)
            {
                rb2d.velocity = new Vector2(0f, ver * velocity);
            }
        }

        if (rb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", rb2d.velocity.x);
            anim.SetFloat("Vel_Y", rb2d.velocity.y);
        }

        if (moveNpc && Vector2.Distance(finalPos, _transform.position) <= 0.1f)
        {
            rb2d.velocity = Vector2.zero;
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
                rb2d.velocity = new Vector2(Mathf.Sign( finalPos.x - _transform.position.x) * velocity, 0f);
            }
            else
            {
                //Move o npc em y

                finalPos = new Vector2(_transform.position.x, GetPosition('y'));
                rb2d.velocity = new Vector2(0f, Mathf.Sign(finalPos.y - _transform.position.y) * velocity);
            }

            yield return (new WaitForSeconds(5f));
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
}
