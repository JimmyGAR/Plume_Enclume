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

        yield return new WaitForSeconds(0.5f);

        myCanvasMenu.gameObject.SetActive(true);
        panelLevels.gameObject.SetActive(false);
    }

    public void StartLevel1()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void StartLevel2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void StartLevel3()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
