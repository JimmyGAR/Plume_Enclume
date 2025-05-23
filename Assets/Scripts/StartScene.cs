using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
