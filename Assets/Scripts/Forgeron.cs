using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class Forgeron : MonoBehaviour
{
    public ShakeData ForgeronShaker;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        CameraShakerHandler.Shake(ForgeronShaker);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
