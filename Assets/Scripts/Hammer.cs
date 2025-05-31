using UnityEngine;
using System.Collections;
using System;
using FirstGearGames.SmoothCameraShaker;

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

        StartCoroutine(WaitForFallAndLand());

        StartCoroutine(WaitAndDoSomething());
    }

    IEnumerator WaitForFallAndLand()
    {
        yield return new WaitWhile(() => IsGrounded());

        yield return new WaitUntil(() => IsGrounded());

        CameraShakerHandler.Shake(HammerShaker);
        rb.bodyType = RigidbodyType2D.Static;
    }


    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5f);

        boxCollider2D.enabled = false;

        Play();

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(.1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
