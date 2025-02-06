using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyBonus(collision.gameObject);
        }
    }

    protected abstract void ApplyBonus(GameObject player);
}