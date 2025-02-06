using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth { get { return maxHealth; } }
    public int СurrentHealth { get; private set; }
    public bool IsDead => СurrentHealth <= 0;

    public event Action<int> OnHealthChanged;
    private void Awake()
    {
        СurrentHealth = maxHealth;
    }
   
    public void TakeDamage(int damage)
    {
        СurrentHealth = Mathf.Clamp(СurrentHealth - damage, 0, maxHealth);
        OnHealthChanged?.Invoke(СurrentHealth);
        if (IsDead)
        {
            Die();
        }
    }
  
    public void Heal(int amount)
    {
        СurrentHealth = Mathf.Clamp(СurrentHealth +amount, 0, maxHealth);
        OnHealthChanged?.Invoke(СurrentHealth);
    }

   private void Die()
   {
       GameManager.Instance.GameOver();
   }
}