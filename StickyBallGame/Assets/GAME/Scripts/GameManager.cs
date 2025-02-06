using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public GameObject player;
    private int Score = 0;
    private float startY;
    
    public event Action<int> OnScoreChanged;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        startY = player.transform.position.y;
    }

    private void LateUpdate()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        float currentY = player.transform.position.y;
        Score = Mathf.RoundToInt(currentY-startY);
        OnScoreChanged?.Invoke(Score);
    }
}