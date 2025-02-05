using UnityEngine;

public class StickyBall : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerController playerController;
    public Vector2 GetPosition() => transform.position;

    public void Initialize(PlayerController player)
    {
        playerController = player;
    }

    public void OnTap()
    {
        Debug.Log("Sticky ball tapped");
        playerController?.AttachToStickySphere(this);
    }
}