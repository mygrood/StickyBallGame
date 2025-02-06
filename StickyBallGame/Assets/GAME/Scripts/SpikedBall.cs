using UnityEngine;

public class SpikedBall:Obstacle
{
    [SerializeField] private float pushForce = 5f;
    protected override void HandlePlayerCollision(GameObject player)
    {
        base.HandlePlayerCollision(player);
        
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            Vector2 pushDirection = player.transform.position - transform.position;
            pushDirection.Normalize(); 
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); 
        }
        Destroy(gameObject);
    }
}