using UnityEngine;

public class BlockTrap : MonoBehaviour
{
    public GameObject connectedBlock; // The block that will be connected to the trap
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>()); 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            connectedBlock.AddComponent<Rigidbody2D>();
        }
    }
}

}
