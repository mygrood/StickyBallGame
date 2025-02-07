using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player;
    public bool isPaused = false;
    
    private int Score = 0;
    private float startY;
    
    public event Action<int> OnScoreChanged;
    public event Action<int, int> OnGameOver;

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
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1; 
        }
    }

    private void UpdateScore()
    {
        float currentY = player.transform.position.y;
        Score = Mathf.RoundToInt(currentY - startY);
        OnScoreChanged?.Invoke(Score);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        SetHighScore(Score);
        OnGameOver?.Invoke(Score, GetHighScore());
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private void SetHighScore(int score)
    {
        int highScore = GetHighScore();
        if (score > highScore) PlayerPrefs.SetInt("HighScore", score);
    }
}