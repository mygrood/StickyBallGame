using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    public int СurrentHealth { get; private set; }
    public bool IsDead => СurrentHealth <= 0;

    private void Awake()
    {
        СurrentHealth = maxHealth;
    }
   
    public void TakeDamage(int damage)
    {
        СurrentHealth = Mathf.Clamp(СurrentHealth - damage, 0, maxHealth);
        if (IsDead)
        {
            Die();
        }
    }
  
    public void Heal(int amount)
    {
        
        СurrentHealth = Mathf.Clamp(СurrentHealth +amount, 0, maxHealth);
    }

   private void Die()
    {
        Debug.Log("Player has died.");
    }
}