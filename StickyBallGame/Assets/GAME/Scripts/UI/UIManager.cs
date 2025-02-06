using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    
    private void Start()
    {
       GameManager.Instance.OnScoreChanged+=UpdateScoreText;

    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}