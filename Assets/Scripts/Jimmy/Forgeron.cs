using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.UI;

public class Forgeron : MonoBehaviour
{
    public Canvas Victory;
    public GameObject Hammer;
    public GameObject Spikes;
    public ShakeData ForgeronShaker;
    public float healthMax;
    public float currentHealth;
    AudioSource victoryMusic;
    public AudioManager audioManager;
    Animator animator;
    public Image bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Victory.gameObject.SetActive(false);
        victoryMusic = GetComponent<AudioSource>();

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
            audioManager.PlayEnding();
            victoryMusic.Play();
            Destroy(bar);
            Hammer.SetActive(false);
            Spikes.SetActive(false);
            Destroy(gameObject, victoryMusic.clip.length);
            Victory.gameObject.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
    }
}
