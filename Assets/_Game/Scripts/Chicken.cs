using UnityEngine;
using DG.Tweening;

public class Chicken : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody2D myRigibody2d;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigibody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        mySpriteRenderer.flipX = myRigibody2d.velocity.x < 0 ? true : false;
        myAnimator.SetFloat("Velocity", myRigibody2d.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
