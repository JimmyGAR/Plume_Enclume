using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.UI;

public class Forgeron : MonoBehaviour
{
    public ShakeData ForgeronShaker;
    public int healthMax;
    public int currentHealth;
    Animator animator;
    public Image bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        CameraShakerHandler.Shake(ForgeronShaker);
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        bar.fillAmount = (float)currentHealth / healthMax;
    }
}
