using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class CollisionEnclumeJimmy : MonoBehaviour
{

    public int life = 3;
    //public int apples = 0;
    Rigidbody2D rb;
    Animator animator;
    bool isDied = false;

    /// <summary>
    /// Fonction de démarrage qui permet en grande partie d'intialiser les variables qui seront utilisées plus tard
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Fonction qui va fonctionné à chaque que le joueur va être en collision avec un obejt qui porte un tag différent (ici spike)
    /// </summary>
    /// <author> GARNIER Jimmy </author>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.tag != "StabiliseEnclume" && gameObject.layer != LayerMask.NameToLayer("ground")) // Permet de dire que si Enclume est dans sa phase de "stabilise", il ne meurt pas
        {
            if (collision.CompareTag("Spike"))
            {
                TakeDamage(3);
            }
        }

        /* Code qui oblige à ce que les pommes soit récupérées avant de pouvoir finir le level
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

    /// <summary>
    /// Fonction qui permet de prendre les dommages reçus lors d'une collision avec un autre objet
    /// </summary>
    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0 && !isDied)
        {
            Die();
        }
    }

    /// <summary>
    /// Fonction qui permet de dire quand le personnage est mort
    /// </summary>
    /// <author> GARNIER Jimmy </author>
    public void Die()
    {
        isDied = true;

        rb.bodyType = RigidbodyType2D.Static;

        animator.Play("EnclumeDieAnimation"); // lance l'animation de mort d'Enclume

        StartCoroutine(WaitAndDoSomething()); // lance une fonction qui est équivalent à un wait() 
    }

    /// <summary>
    /// Fonction qui attend un certain temps (dans ce cas 0.1 seconde) avant d'exécuter le code qui le suit
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(0.1f);

        Invoke("RestartLevel", 1);
    }

    /// <summary>
    /// Relance le level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
