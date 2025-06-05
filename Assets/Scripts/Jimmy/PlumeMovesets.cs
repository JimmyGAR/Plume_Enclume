using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class qui est la faculté de Plume, attaquer le boss final
/// </summary>
/// <author> GARNIER Jimmy </author>
public class PlumeMovesets : MonoBehaviour
{
    public Forgeron forgeron;
    private bool isHolding = false; // permet de faire une bouble lorsque le joueur appuie sur S, sans ça l'attaque se fait qu'une seule fois et n'est pas répété
    private bool isHere = false; // permet d'indiquer si le boss est présent
    Animator animator; // animation de la plume quand elle attaque
    AudioSource attackSound; // récupère le son d'attaque initialisé dans le personnage

    /// <summary>
    /// Fonction de démarrage qui permet en grande partie d'intialiser les variables qui seront utilisées plus tard
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    private void Start()
    {
        animator = GetComponent<Animator>();
        attackSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Fonction qui est active régulièrement (PS : fixedUpdate est active encore plus souvent que celle là)
    /// </summary>
    /// <author> GARNIER Jimmy</author>
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

    /// <summary>
    /// Attaque de Plume
    /// </summary>
    /// <author> GARNIER Jimmy</author>
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

    /// <summary>
    /// Fonction qui permet de dire si Plume est dans la zone (hitbox) du boss et si il est possible d'attaquer (faire des dégâts) au boss
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Forgeron"))
        {
            isHere = true;
        }
    }

    /// <summary>
    /// Fonction similaire à celle présente ci-dessus mais permet de dire quand Plume n'est pas dans la zone
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Forgeron"))
        {
            isHere = false;
        }
    }
}
