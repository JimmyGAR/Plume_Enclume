using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static int totalApples = 0;

    public static bool plumeArrived = false;
    public static bool enclumeArrived = false;

    public int requiredApples = 14;
    private bool levelEnded = false;

    void Update()
    {
        if (!levelEnded && plumeArrived && enclumeArrived)
        {
            if (totalApples == requiredApples)
            {
                Debug.Log("Victoire !");
                levelEnded = true; 
                SceneManager.LoadScene("VictoryScreen_N1"); // passage au victory screen
            }
            else
            {
                Debug.Log("Il manque des pommes !");
                levelEnded = true; 
            }
        }
    }

    public static void ResetGame()
    {
        totalApples = 0;
        plumeArrived = false;
        enclumeArrived = false;
    }


    public static void AddApple()
    {
        totalApples++;
        Debug.Log("Pommes collectées : " + totalApples);
    }

    public static void PlayerArrived(string who)
    {
        if (who == "Plume")
        {
            plumeArrived = true;
        }
        if (who == "Enclume")
        {
            enclumeArrived = true;
        }
    }
}
