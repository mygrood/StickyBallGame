using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameoverHighScoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        GameManager.Instance.OnGameOver += ShowGameOver;

        gameOverPanel.SetActive(false);
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
}