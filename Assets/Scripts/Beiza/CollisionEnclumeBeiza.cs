using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionEnclumeBeiza : MonoBehaviour
{
    public int life = 3;
    public int apples = 0;
    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Spike"))
        {
            TakeDamage(3);
        }

        if (collision.CompareTag("Apple"))
        {
            EndGameBeiza.totalApples++;
            Debug.Log("Total pommes : " + EndGameBeiza.totalApples);
            Destroy(collision.gameObject);
        }


        if (collision.CompareTag("EndLevelBeiza"))
        {
            EndGameBeiza.PlayerArrived("Enclume");
        }

    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Die();
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;

        animator.Play("EnclumeDieAnimation");

        StartCoroutine(WaitAndDoSomething());
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(0.5f);

        Invoke("RestartLevel", 1);
    }

    public void RestartLevel()
    {
        EndGameBeiza.ResetGame(); // reset des variables de fin de jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}