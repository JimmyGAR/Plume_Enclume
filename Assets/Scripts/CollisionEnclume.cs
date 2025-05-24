using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEnclume : MonoBehaviour
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
            apples++;
            Destroy(collision.gameObject);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
