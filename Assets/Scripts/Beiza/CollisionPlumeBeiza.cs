using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlumeBeiza : MonoBehaviour
{
    public int life = 3;
    public int apples = 0;

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
            EndGameBeiza.PlayerArrived("Plume");
        }

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
        EndGameBeiza.ResetGame(); // reset des variables de fin de jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

