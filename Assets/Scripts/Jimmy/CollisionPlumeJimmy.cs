using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionPlumeJimmy : MonoBehaviour
{
    
    public int life = 3;
    public int apples = 0;
    bool isDied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Spike"))
        {
            TakeDamage(3);
        }

        /* Tu peux garder ou changer ce code : cest pour que toutes le pommes soient recup�r�s sinon pas de fin de jeu
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

        if (life <= 0 && !isDied)
        {
            Die();
        }
    }

    public void Die()
    {
        isDied = true;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 90);
        GetComponent<Collider2D>().isTrigger = true;
        Invoke("RestartLevel", 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

