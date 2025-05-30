using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionEnclumeBeiza : MonoBehaviour
{
    public int life = 3;
    public int apples = 0;
    Animator animator;

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