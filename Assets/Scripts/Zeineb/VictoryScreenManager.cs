using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenManager : MonoBehaviour
{
    public float delayBeforeNextLevel = 5f; // Temps en secondes avant de passer au niveau suivant
    public string nextLevelName = "Beiza";  

    void Start()
    {
        Invoke("LoadNextLevel", delayBeforeNextLevel);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}

