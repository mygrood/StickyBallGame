using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player;
    
    private bool _isPaused = false;
    public bool IsPaused
    {
        get => _isPaused;
        set
        {
            _isPaused = value;
            UpdateTimeScale();
        }
    }
    public bool IsGameOver { get; private set; } = false;
    
    private int score = 0;
    private float startY;
    
    public event Action<int> OnScoreChanged;
    public event Action<int, int> OnGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        SoundManager.Instance.SetGameMusic();
        startY = player.transform.position.y;
    }

    private void Update()
    {
        if (player == null || IsGameOver) return;

        UpdateScore();
    }

    private void UpdateTimeScale()
    {
        Time.timeScale = (IsPaused || IsGameOver) ? 0 : 1;
    }

    private void UpdateScore()
    {
        float currentY = player.transform.position.y;
        score = Mathf.RoundToInt(currentY - startY);
        OnScoreChanged?.Invoke(score);
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        
        SoundManager.Instance.SetGameOverMusic();
        IsGameOver = true;
        SetHighScore(score);
        OnGameOver?.Invoke(score, GetHighScore());
        UpdateTimeScale();
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private void SetHighScore(int score)
    {
        int highScore = GetHighScore();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save(); 
        }
    }
    public void StartGame()
    {
        IsPaused = false; 
    }
}