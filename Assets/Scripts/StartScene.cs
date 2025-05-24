using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class StartScene : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer forgeron;
    public SpriteRenderer logo;
    public Canvas myCanvasStart;
    public Canvas myCanvasMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        myCanvasMenu.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAnimationStart()
    {
        animator.SetBool("Start", true);
        myCanvasStart.gameObject.SetActive(false);

        StartCoroutine(WaitAndDoSomething());
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);

        Destroy(forgeron.gameObject);
        Destroy(logo.gameObject);

        myCanvasMenu.gameObject.SetActive(true);
    }
}
