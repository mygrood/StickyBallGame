using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rope rope;

    private Rigidbody2D rb;
    private static Vector2 moveDirection = Vector2.up;
    private StickyBall currentStickyBall;

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
            if (rb.velocity.magnitude < moveSpeed) rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Force);
        }
        else
        {
            Vector2 direction = (currentStickyBall.GetPosition() - transform.position).normalized;
            rb.velocity = direction * moveSpeed; 
            rope.UpdateRope(transform.position, currentStickyBall.GetPosition());
        }
    }

    public void HandleStickyInteraction(StickyBall stickyBall)
    {
        if (currentStickyBall == stickyBall)
        {
            rope.Detach();
            currentStickyBall = null;
            isAttached = false;
        }
        else
        {
            if (currentStickyBall != null)
            {
                rope.Detach();
            }

            currentStickyBall = stickyBall;
            rope.Attach(transform.position, currentStickyBall.GetPosition());
            isAttached = true;
        }
    }
}