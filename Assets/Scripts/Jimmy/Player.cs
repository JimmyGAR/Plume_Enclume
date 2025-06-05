using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Classe principale du joueur
/// </summary>
/// <author> GARNIER Jimmy </author>
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

    /// <summary>
    /// Semblable à Update mais est appelé beaucoupl plus souvent, permettant des déplacement plus régulier sans arrêt
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    void FixedUpdate()
    {
        if (gameObject.tag != "StabiliseEnclume" && gameObject.layer != LayerMask.NameToLayer("ground"))
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
    }

    /// <summary>
    /// Fonction qui permet au joueur de bouger
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        if (horizontal != 0 && flip)
        {
            sr.flipX = horizontal < 0;
        }
    }

    /// <summary>
    /// Fonction qui permet au joueur de sauter
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }

    /// <summary>
    /// Fonction qui permet de savoir si le personnage est présent sur le sol (à partir d'un objet empty situé au pieds de chaque personnage)
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    bool IsGrounded()
    {
        // Permet d'ajouter un micro composant invisible qui va permettre de savoir si il touche le sol (le sol étant configuré sur le layer "ground")
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(.1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

   
}
