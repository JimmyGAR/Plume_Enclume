using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

/// <summary>
/// permet de faire une animation et un changement de composants pour la scène principal
/// </summary>
/// <author> GARNIER Jimmy </author>
public class StartScene : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer forgeron;
    public SpriteRenderer logo;
    public SpriteRenderer AnimMenu;
    public Animator menuAnimation; // pour l'animation
    public Canvas myCanvasStart; // pour les différents canvas (menu)
    public Canvas myCanvasMenu;
    public GameObject panelLevels; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        myCanvasMenu.gameObject.SetActive(false);
        AnimMenu.gameObject.SetActive(false);
        forgeron.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        myCanvasStart.gameObject.SetActive(true);
    }

    /// <summary>
    /// Fonction qui permet de fermer l'application
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Fonction qui permet de lancer l'animation
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void PlayAnimationStart()
    {
        animator.SetBool("Start", true);
        myCanvasStart.gameObject.SetActive(false); // affiche le composant normalement caché

        StartCoroutine(WaitAndDoSomething());// lance une fonction qui est équivalent à un wait() 
    }

    /// <summary>
    /// Fonction qui attend un certain temps (dans ce cas 0.1 seconde) avant d'exécuter le code qui le suit
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);

        Destroy(forgeron.gameObject); // détruit un composant
        Destroy(logo.gameObject);

        AnimMenu.gameObject.SetActive(true); 

        menuAnimation.SetBool("Start", true);

        yield return new WaitForSeconds(0.5f);

        myCanvasMenu.gameObject.SetActive(true);
        panelLevels.gameObject.SetActive(false);
    }

    /// <summary>
    /// Fonction qui lance le premier level
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void StartLevel1()
    {
        SceneManager.LoadSceneAsync(1); // IMPORTANT = l'indice 1 correspond à sa place dans l'arbre des scènes, nous pouvons le changer pour dire quelle scène doit intervenir en premier lors du lancement du jeux
    }

    /// <summary>
    /// Fonction qui lance le deuxième level
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void StartLevel2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    /// <summary>
    /// Fonction qui lance le troisième level
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void StartLevel3()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
