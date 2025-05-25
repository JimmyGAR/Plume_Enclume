using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionPlumeJimmy : MonoBehaviour
{
    
    public int life = 3;
    public int apples = 0;

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
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 150);
        GetComponent<Collider2D>().isTrigger = true;
        Invoke("RestartLevel", 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

