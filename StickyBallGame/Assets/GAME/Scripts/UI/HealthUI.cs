using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Transform healthBar;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    PlayerHealth playerHealth;
    private Image[] hearts;

    private void Start()
    {
        playerHealth = GameManager.Instance.player.gameObject.GetComponent<PlayerHealth>();
        playerHealth.OnHealthChanged += UpdateUI;

        InitializeUI();
    }

    private void InitializeUI()
    {
        int maxHealth = playerHealth.MaxHealth;
        hearts = new Image[maxHealth];
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartObject = Instantiate(heartPrefab, healthBar);
            hearts[i] = heartObject.GetComponent<Image>();
        }
        UpdateUI(playerHealth.СurrentHealth);
    }

    private void UpdateUI(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}