using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpingPower;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool flip = false;
    float horizontal;
    SpriteRenderer sr;
    Animator animator;
    bool gameIsPaused;
    public PauseMenu pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", IsGrounded());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                pauseMenu.Resume();
                gameIsPaused = false;
            } else
            {
                pauseMenu.Pause();
                gameIsPaused = true;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        if (horizontal != 0 && flip)
        {
            sr.flipX = horizontal < 0;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }


    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(.1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

   
}
