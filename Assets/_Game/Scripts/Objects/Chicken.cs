using System.Collections;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] float speed;
    private Animator myAnimator;
    private BoxCollider2D myBoxCollider2D;
    private Rigidbody2D myRigibody2d;
    private SpriteRenderer mySpriteRenderer;
    private bool running;
    private Coroutine stopRunning;
    private Coroutine checkPlayer;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigibody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!running)
            return;
        Vector2 direction = transform.position;
        direction -= other.GetContact(0).point;
        direction *= -1;
        direction.Normalize();
        direction *= speed;
        direction *= GetAxisCollision(other.GetContact(0).normal);
        myRigibody2d.velocity = direction;
        mySpriteRenderer.flipX = direction.x < 0 ? true : false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkPlayer = StartCoroutine(CheckPlayerDirection(other));
            running = true;
            if (stopRunning != null)
            {
                StopCoroutine(stopRunning);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stopRunning = StartCoroutine(StopRunning());
            running = false;
            if (checkPlayer != null)
            {
                StopCoroutine(checkPlayer);
            }
        }
    }

    private Vector2 GetAxisCollision(Vector2 collisionNormal)
    {
        float angle = Vector2.Angle(Vector2.up, collisionNormal);

        if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180))
        {
            return new Vector2(1f, -1f);
        }
        else if (Mathf.Approximately(angle, 90))
        {
            return new Vector2(-1f, 1f);
        }
        else
        {
            return new Vector2(-1f, -1f);
        }
    }

    private IEnumerator CheckPlayerDirection(Collider2D other)
    {
        while (true)
        {
            Vector2 myPosition = transform.position;
            Vector2 direction = transform.position - other.transform.position;
            mySpriteRenderer.flipX = direction.x < 0 ? true : false;
            direction = Vector2.ClampMagnitude(direction, 1.0f) * speed;
            myRigibody2d.velocity = direction;
            myAnimator.SetFloat("Velocity", 1.0f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(0.5f);
        Vector2 speedA = myRigibody2d.velocity;
        for (float i = 0; i <= 1; i += 0.2f)
        {
            myRigibody2d.velocity = Vector2.Lerp(speedA, Vector2.zero, i);
            yield return new WaitForSeconds(1.0f / 10);
        }
        myRigibody2d.velocity = Vector2.zero;
        myAnimator.SetFloat("Velocity", 0.0f);
    }
}