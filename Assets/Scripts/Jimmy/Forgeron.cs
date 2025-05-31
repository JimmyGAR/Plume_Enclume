using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.UI;

public class Forgeron : MonoBehaviour
{
    public Canvas Victory;
    public GameObject Hammer;
    public ShakeData ForgeronShaker;
    public float healthMax;
    public float currentHealth;
    Animator animator;
    public Image bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Victory.gameObject.SetActive(false);

        CameraShakerHandler.Shake(ForgeronShaker);
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        if (currentHealth > 0)
        {
            bar.fillAmount = currentHealth / healthMax;
        } else
        {
            Destroy(bar);
            Destroy(gameObject);
            Destroy(Hammer);
            Victory.gameObject.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
    }
}
