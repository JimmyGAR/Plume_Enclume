using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu pause pour pouvoir retourner au menu principal, relancer le niveau ou encore le reprendre
/// </summary>
/// <author> GARNIER Jimmy </author>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    /// <summary>
    /// Pause
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // Permet d'arrêter le jeu en arrière plan
    }

    /// <summary>
    /// Menu principal
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // Permet de reprendre le jeu (continuer la partie)
    }

    /// <summary>
    /// Permet de continuer la partie
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// permet de relancer le niveau actuel
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
