using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionEnclumeJimmy : MonoBehaviour
{

    public int life = 3;
    //public int apples = 0;
    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Spike"))
        {
            TakeDamage(3);
        }

        /* Tu peux garder ou changer ce code : cest pour que toutes le pommes soient recupérés sinon pas de fin de jeu
        if (collision.CompareTag("Apple"))
        {
            EndGameManager.totalApples++;
            Debug.Log("Total pommes : " + EndGameManager.totalApples);
            Destroy(collision.gameObject);
        }


        // Ca cest pour que la plume arrive a la fin du niveau
        if (collision.CompareTag("EndLevel"))
        {
            EndGameManager.PlayerArrived("Enclume");
        }
        */

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
        yield return new WaitForSeconds(0.1f);

        Invoke("RestartLevel", 1);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
