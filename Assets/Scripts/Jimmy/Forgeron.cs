using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.UI;
using System.Threading;

/// <summary>
/// Boss du level 3
/// </summary>
/// <author> GARNIER Jimmy </author>
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
    /// <author> GARNIER Jimmy</author>
    void Start()
    {
        animator = GetComponent<Animator>();
        Victory.gameObject.SetActive(false);
        victoryMusic = GetComponent<AudioSource>();

        CameraShakerHandler.Shake(ForgeronShaker);
    }

    // Update is called once per frame
    /// <author> GARNIER Jimmy</author>
    public void UpdateHealth()
    {
        if (currentHealth > 0) // si le boss a encore de la vie
        {
            bar.fillAmount = currentHealth / healthMax; // permet de changer la barre de vie du boss
        } else // sinon cela indique les deux joueurs ont gagnés
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

    /// <summary>
    /// Fonction qui inflige des dommages au boss
    /// </summary>
    /// <author> GARNIER Jimmy</author>
    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
    }
}
