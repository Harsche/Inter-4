using UnityEngine;
using DG.Tweening;

public class Chicken : MonoBehaviour
{
    [SerializeField] float runDistance;
    [SerializeField] float runTime;
    private Animator myAnimator;
    private Rigidbody2D myRigibody2d;
    private SpriteRenderer mySpriteRenderer;
    private Tween run;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigibody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        run.Kill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 myPosition = transform.position;
            Vector2 distance = transform.position - other.transform.position;
            mySpriteRenderer.flipX = distance.x < 0 ? true : false;
            distance = myPosition + Vector2.ClampMagnitude(distance, 1.0f) * runDistance;
            run = myRigibody2d.DOMove(distance, runTime);

            myAnimator.SetFloat("Velocity", 1.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        myAnimator.SetFloat("Velocity", 0.0f);
    }
}