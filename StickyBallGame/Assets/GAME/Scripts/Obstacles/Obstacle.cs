using UnityEngine;


public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected int damageAmount=1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision(collision.gameObject);
        }
    }

    
    protected virtual void HandlePlayerCollision(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damageAmount);
    }
}