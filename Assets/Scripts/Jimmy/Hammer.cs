using UnityEngine;
using System.Collections;
using System;
using FirstGearGames.SmoothCameraShaker;
using Unity.VisualScripting;

/// <summary>
/// Attaque/piège du forgeron - un marteau qui s'abat sur le joueur
/// </summary>
/// <author> GARNIER Jimmy </author>
public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public ShakeData HammerShaker;
    public GameObject go;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D Plume;
    public Rigidbody2D Enclume;
    Vector2 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = go.GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        boxCollider2D = go.GetComponent<BoxCollider2D>();
        animator = go.GetComponent<Animator>();

        StartCoroutine(WaitAndDoSomething());
    }

    /// <summary>
    /// Marteau frappe aléatoirement le joueur en fonction de sa position, le marteau se lance à la même hauteur, laissant au joeur la possibilité d'esquiver
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Play()
    {
        int random = UnityEngine.Random.Range(0, 2);

        if (random == 0 && (Plume.position.x < 0.4 && Plume.position.x > -5.6))
        {
            rb.position = new Vector2(Plume.position.x, 3.6f);
        }
        else
        {
            rb.position = new Vector2(Enclume.position.x, 3.6f);
        }

        animator.Play("HammerCrashAnimation");
        rb.bodyType = RigidbodyType2D.Dynamic;
        boxCollider2D.enabled = true;

        StartCoroutine(WaitForFallAndLand()); // Permet d'attendre que l'objet atteigne bien le sol

        StartCoroutine(WaitAndDoSomething());
    }

    /// <summary>
    /// Permet d'attendre que l'objet atteigne bien le sol
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    IEnumerator WaitForFallAndLand()
    {
        yield return new WaitWhile(() => IsGrounded());

        yield return new WaitUntil(() => IsGrounded());

        CameraShakerHandler.Shake(HammerShaker); // permet de lancer un effet de tremblement à la caméra
        rb.bodyType = RigidbodyType2D.Static;
        go.layer = LayerMask.NameToLayer("ground");
    }

    /// <summary>
    /// Fonction qui attend un certain temps (dans ce cas 0.1 seconde) avant d'exécuter le code qui le suit
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5f); // toutes les 5 secondes le marteau frappe un joueur aléatoirement

        boxCollider2D.enabled = false;
        go.layer = LayerMask.NameToLayer("Default");

        go.transform.rotation = Quaternion.identity; // réinitialise la rotation (l'objet pouvait tomber et être en biais)

        Play();

    }

    /// <summary>
    /// Permet d'indiquer si le marteau est sur le sol et si il touche le sol
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(.1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
