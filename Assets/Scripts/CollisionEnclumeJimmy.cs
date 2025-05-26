using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionEnclumeJimmy : MonoBehaviour
{

    public int life = 3;
    //public int apples = 0;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool("isDie", true);

        StartCoroutine(WaitAndDoSomething());
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(0.5f);

        Invoke("RestartLevel", 1);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
