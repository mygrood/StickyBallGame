using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager: MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameoverHighScoreText;
    [SerializeField] private GameObject pausePanel;
    
    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        GameManager.Instance.OnGameOver += ShowGameOver;

        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void ShowGameOver(int score, int highScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
        gameoverHighScoreText.text = "Highscore: " + highScore.ToString();
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MENU"); 
    }

    public void TogglePause()
    {
        GameManager.Instance.isPaused = !GameManager.Instance.isPaused;
        pausePanel.SetActive(GameManager.Instance.isPaused);
    }
    
}