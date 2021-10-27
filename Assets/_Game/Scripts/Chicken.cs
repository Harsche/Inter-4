using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Chicken : MonoBehaviour
{
    [SerializeField] float speed;
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
            Vector2 direction = transform.position - other.transform.position;
            mySpriteRenderer.flipX = direction.x < 0 ? true : false;
            direction = Vector2.ClampMagnitude(direction, 1.0f) * speed;
            myRigibody2d.velocity = direction;

            myAnimator.SetFloat("Velocity", 1.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Coroutine stopCoroutine = StartCoroutine(StopRunning());
        }

    }

    IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(0.5f);
        myRigibody2d.velocity = Vector2.zero;
        myAnimator.SetFloat("Velocity", 0.0f);
    }
}