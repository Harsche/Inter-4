using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class Movement : MonoBehaviour
{
    public static Movement PlayerMovement { get; private set; }
    [SerializeField] private float speed;
    [SerializeField] private float deadzone;
    [SerializeField] private float joystickSize;
    [SerializeField] private GameObject circle;

    [SerializeField] private GameObject canvasJoystick;
    [SerializeField] private AudioClip[] insideFootsteps;
    [SerializeField, Range(0, 1)] private float insideFootstepsVolume = 1;
    [SerializeField] private AudioClip[] outsideFootsteps;
    [SerializeField, Range(0, 1)] private float outsideFootstepsVolume = 1;
    
    private Transform myTransform;
    public bool canMove = true;
    public bool animateByTransform;
    public SpriteRenderer spriteRenderer { get; private set;}
    public static Animator anim { get; private set; }
    public static BoxCollider2D boxCollider2D { get; private set; }
    private GameObject circleCenter;
    private GameObject circleDirection;
    private Rigidbody2D myRb2d;
    private Vector2 deltaPosition;
    private Vector3 lastPosition;

    private void Start()
    {
        if (PlayerMovement != null && gameObject.name.Contains("Player"))
            Destroy(gameObject);
        PlayerMovement = this;
        myTransform = transform;
        lastPosition = myTransform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        myRb2d = GetComponent<Rigidbody2D>();
        circleCenter = Instantiate(circle);
        circleCenter.name = "Center";
        circleDirection = Instantiate(circle);
        circleDirection.name = "Direction";
        circleCenter.transform.SetParent(canvasJoystick.transform.GetChild(0));
        circleDirection.transform.SetParent(canvasJoystick.transform.GetChild(0));
        canvasJoystick.SetActive(false);
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animateByTransform = true;


        circleCenter.GetComponent<Image>().color *= new Color(1.0f, 1.0f, 1.0f, 0.25f);

    }

    private void Update()
    {
        if (!canMove)
        {
            deltaPosition = myTransform.position - lastPosition;
            lastPosition = myTransform.position;
        }
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (canMove)
        {
            UpdateAnimationByRigidbody();
            return;
        }
        UpdateAnimationByTransform();
    }

    private void UpdateAnimationByRigidbody()
    {
        anim.SetFloat("Velocity", myRb2d.velocity.magnitude);
        if (myRb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", myRb2d.velocity.x);
            anim.SetFloat("Vel_Y", myRb2d.velocity.y);
            spriteRenderer.flipX = myRb2d.velocity.x >= 0 ? false : true;
        }
    }

    private void UpdateAnimationByTransform()
    {
        if(!animateByTransform)
            return;
        Vector2 offset = deltaPosition.normalized;
        anim.SetFloat("Velocity", offset.magnitude);
        if (offset.magnitude != 0)
        {
            anim.SetFloat("Vel_X", offset.x);
            anim.SetFloat("Vel_Y", offset.y);
            spriteRenderer.flipX = offset.x >= 0 ? false : true;
        }
    }

    public void Move(LeanFinger finger)
    {
        if (enabled)
        {
            Vector2 direction = finger.ScreenPosition - finger.StartScreenPosition;

            if (!finger.Up && canMove)
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

    public void PlayFootstep(){
        var player = Player.Instance;
        AudioClip[] footsteps = Player.playerData.isInside ? insideFootsteps : outsideFootsteps;
        float volume = Player.playerData.isInside ? insideFootstepsVolume : outsideFootstepsVolume;
        AudioClip clip = footsteps[Random.Range(0, footsteps.Length)];
        player.AudioSource.PlayOneShot(clip, volume);
    }
}
