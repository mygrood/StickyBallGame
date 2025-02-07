using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TopPanelAnimation settingsPanelAnimation;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;


    [SerializeField] private TopPanelAnimation highScorePanelAnimation;
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        SoundManager.Instance.SetMenuMusic();
    }
    
    public void ToggleSettings()
    {
        
        if (settingsPanelAnimation != null)
        {
            if (settingsPanelAnimation.IsOpen)
                settingsPanelAnimation.Close();
            else
                settingsPanelAnimation.Open();
            
            bool isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
            soundButtonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        }
    }

    public void ToggleHighScore()
    {
        if (highScorePanelAnimation != null)
        {
            if (highScorePanelAnimation.IsOpen)
            {
                highScorePanelAnimation.Close();
            }
            else
            {
                highScorePanelAnimation.Open();
                highScoreText.text = "Highscore: "+GetHighScore().ToString(); 
            }
        }
       
    }

    public void ToggleSoundButton()
    {
        SoundManager.Instance.ToggleSound();
        UpdateSoundButtonImage();
    }

    private void UpdateSoundButtonImage()
    {
        bool isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        soundButtonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GAME");
    }

    private int GetHighScore()
    {
       return PlayerPrefs.GetInt("HighScore");
    }
}