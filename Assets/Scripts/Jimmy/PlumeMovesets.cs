using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class qui est la facult� de Plume, attaquer le boss final
/// </summary>
/// <author> GARNIER Jimmy </author>
public class PlumeMovesets : MonoBehaviour
{
    public Forgeron forgeron;
    private bool isHolding = false; // permet de faire une bouble lorsque le joueur appuie sur S, sans �a l'attaque se fait qu'une seule fois et n'est pas r�p�t�
    private bool isHere = false; // permet d'indiquer si le boss est pr�sent
    Animator animator; // animation de la plume quand elle attaque
    AudioSource attackSound; // r�cup�re le son d'attaque initialis� dans le personnage

    /// <summary>
    /// Fonction de d�marrage qui permet en grande partie d'intialiser les variables qui seront utilis�es plus tard
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    private void Start()
    {
        animator = GetComponent<Animator>();
        attackSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Fonction qui est active r�guli�rement (PS : fixedUpdate est active encore plus souvent que celle l�)
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
    /// Fonction qui permet de dire si Plume est dans la zone (hitbox) du boss et si il est possible d'attaquer (faire des d�g�ts) au boss
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
    /// Fonction similaire � celle pr�sente ci-dessus mais permet de dire quand Plume n'est pas dans la zone
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
