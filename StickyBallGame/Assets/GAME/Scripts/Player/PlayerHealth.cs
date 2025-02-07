using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth { get { return maxHealth; } }
    public int СurrentHealth { get; private set; }
    public bool IsDead => СurrentHealth <= 0;
    
     private PlayerAnimation playerAnimation;

    public event Action<int> OnHealthChanged;
    private void Awake()
    {
        СurrentHealth = maxHealth;
        playerAnimation = GetComponent<PlayerAnimation>();
    }
   
    public void TakeDamage(int damage)
    {
        СurrentHealth = Mathf.Clamp(СurrentHealth - damage, 0, maxHealth);
        OnHealthChanged?.Invoke(СurrentHealth);
        playerAnimation.TakeDamage();
        if (IsDead)
        {
            Die();
        }
    }
  
    public void Heal(int amount)
    {
        if (СurrentHealth < maxHealth) 
        {
            СurrentHealth = Mathf.Clamp(СurrentHealth + amount, 0, maxHealth);
            OnHealthChanged?.Invoke(СurrentHealth);
            playerAnimation.Heal();  
        }
    }

   private void Die()
   {
       GameManager.Instance.GameOver();
   }
}