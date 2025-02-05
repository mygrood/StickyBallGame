using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody rb;
    private Vector2 moveDirection = Vector2.up;

    private bool isAttached = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
}
