using UnityEngine;
using UnityEngine.InputSystem;

public class EnclumeMovesets : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rb;
    Animator animator;
    bool isStabilised = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isStabilised = false;
        animator = GetComponent<Animator>();
    }

    public void Stabilise(InputAction.CallbackContext context)
    {
        if (context.performed && !isStabilised)
        {
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.layer = LayerMask.NameToLayer("ground");
            circleCollider2D.enabled = false;
            boxCollider2D.enabled = true;
            animator.SetBool("isStabilised", true);

            isStabilised = true;
        } 
        else if (context.performed && isStabilised) 
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            gameObject.layer = 0;
            circleCollider2D.enabled = true;
            boxCollider2D.enabled = false;
            animator.SetBool("isStabilised", false);

            isStabilised = false;
        }
    }


}
