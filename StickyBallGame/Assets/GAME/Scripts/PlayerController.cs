using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.up;

    private bool isAttached = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!isAttached)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    public void AttachToStickySphere(StickyBall stickyBall)
    {
        throw new System.NotImplementedException();
    }
}
