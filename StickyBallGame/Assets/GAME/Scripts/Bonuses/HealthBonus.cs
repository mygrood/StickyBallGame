using UnityEngine;

public class HealthBonus:Bonus
{
    [SerializeField] private int healAmount;
    protected override void ApplyBonus(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth?.Heal(healAmount);
        
        Destroy(gameObject);
    }
}