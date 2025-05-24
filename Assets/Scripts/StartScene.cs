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
    public SpriteRenderer AnimMenu;
    public Animator menuAnimation;
    public Canvas myCanvasStart;
    public Canvas myCanvasMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        myCanvasMenu.gameObject.SetActive(false);
        AnimMenu.gameObject.SetActive(false);
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

        AnimMenu.gameObject.SetActive(true);

        menuAnimation.SetBool("Start", true);

        yield return new WaitForSeconds(1f);

        myCanvasMenu.gameObject.SetActive(true);
    }
}
