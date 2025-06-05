using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// La particularité d'Enclume (se figer, se stabilisé)
/// </summary>
/// <author> GARNIER Jimmy </author>
public class EnclumeMovesets : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rb;
    AudioSource audioSource;
    Animator animator;
    bool isStabilised = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /// <author> GARNIER Jimmy</author>
    void Start()
    {
        isStabilised = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Fonction qui stabilise le joueur
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Stabilise(InputAction.CallbackContext context)
    {
        if (context.performed && !isStabilised)
        {
            rb.bodyType = RigidbodyType2D.Static; // Enclume ne subit pas la gravité
            gameObject.layer = LayerMask.NameToLayer("ground"); // peut être marché dessus et le marteau s'arrête sur Enclume
            gameObject.tag = "StabiliseEnclume"; // Ajout d'un tag pour confirmer le fait qu'Enclume est stabilisé
            circleCollider2D.enabled = false; // Changement du circle collider 2D de base en box collider 2D (plus apte pour Plume à sauter sur Enclume)
            boxCollider2D.enabled = true;
            animator.SetBool("isStabilised", true); // Joue une petite animation pour signifier que Enclume est bien stabilisé

            isStabilised = true; // Permet de switcher entre cet état et l'état normal

            audioSource.Play(); // SFX (sound effect)
        } 
        else if (context.performed && isStabilised) // inverse vu ci-dessus
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            gameObject.layer = 0;
            gameObject.tag = "Untagged";
            circleCollider2D.enabled = true;
            boxCollider2D.enabled = false;
            animator.SetBool("isStabilised", false);

            isStabilised = false;
        }
    }


}
