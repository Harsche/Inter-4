using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float deadzone;
    [SerializeField] private float joystickSize;
    [SerializeField] private GameObject circle;

    [SerializeField] private GameObject canvasJoystick;
    private Animator anim;
    private GameObject circleCenter;
    private GameObject circleDirection;
    private Rigidbody2D myRb2d;

    private void Start()
    {
        myRb2d = GetComponent<Rigidbody2D>();
        circleCenter = Instantiate(circle);
        circleCenter.name = "Center";
        circleDirection = Instantiate(circle);
        circleDirection.name = "Direction";
        circleCenter.transform.SetParent(canvasJoystick.transform.GetChild(0));
        circleDirection.transform.SetParent(canvasJoystick.transform.GetChild(0));
        canvasJoystick.SetActive(false);
        anim = GetComponent<Animator>();

        circleCenter.GetComponent<Image>().color *= new Color(1.0f, 1.0f, 1.0f, 0.25f);

    }

    private void FixedUpdate()
    {
        anim.SetFloat("Velocity", myRb2d.velocity.magnitude);

        if (myRb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", myRb2d.velocity.x);
            anim.SetFloat("Vel_Y", myRb2d.velocity.y);
        }
    }

    public void Move(LeanFinger finger)
    {
        Vector2 direction = finger.ScreenPosition - finger.StartScreenPosition;

        if (!finger.Up)
        {
            if (finger.Down)
            {
                circleCenter.transform.position = finger.StartScreenPosition;
            }

            circleDirection.transform.position = finger.StartScreenPosition + Vector2.ClampMagnitude(direction, joystickSize);
            canvasJoystick.SetActive(true);

            if (direction.magnitude > deadzone)
            {
                myRb2d.velocity = Vector2.ClampMagnitude(direction, 1) * speed;
            }
            else
            {
                myRb2d.velocity = Vector2.zero;
            }
        }
        else
        {
            myRb2d.velocity = Vector2.zero;
            canvasJoystick.SetActive(false);
        }
    }
}
