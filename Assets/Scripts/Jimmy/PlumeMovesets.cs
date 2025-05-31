using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlumeMovesets : MonoBehaviour
{
    public Forgeron forgeron;
    private bool isHolding = false;
    private bool isHere = false;
    Animator animator;
    AudioSource attackSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isHolding && isHere)
        {
            if (forgeron.currentHealth > 0)
            {
                forgeron.TakeDamage(0.1f);
                forgeron.UpdateHealth();
            }
        }
    }

    public void Damage(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isAttacking", true);
            attackSound.Play();
            isHolding = true;
        }
        else if (context.canceled)
        {
            animator.SetBool("isAttacking", false);
            isHolding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Forgeron"))
        {
            isHere = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Forgeron"))
        {
            isHere = false;
        }
    }
}
