using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static int totalApples = 0;

    public static bool plumeArrived = false;
    public static bool enclumeArrived = false;

    public int requiredApples = 14;

    void Update()
    {
        if (plumeArrived && enclumeArrived)
        {
            if (totalApples == requiredApples)
            {
                Debug.Log("Victoire !");
                // Charger le niveau 2 
                SceneManager.LoadScene("Beiza");

            }
            else
            {
                Debug.Log("Il manque des pommes !");
            }
        }

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
        if (who == "Enclume") enclumeArrived = true;
    }
}
