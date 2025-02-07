using UnityEngine;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject[] slides;
    [SerializeField] private GameObject nextStepButton;

    private int currentStep = 0;

    private void Start()
    {
        tutorial.SetActive(false);
        GameManager.Instance.IsPaused = true;

        if (IsTutorialNeeded())
        {
            tutorial.SetActive(true);
            ShowSlide(currentStep);
        }
        else
        {
            GameManager.Instance.StartGame();
        }
        
    }

    private void ShowSlide(int i)
    {
        GameObject slide = slides[i];
        slide.SetActive(true);

        CanvasGroup slideCanvasGroup = slide.GetComponent<CanvasGroup>();
        if (slideCanvasGroup == null)
            slideCanvasGroup = slide.AddComponent<CanvasGroup>();

        slideCanvasGroup.alpha = 0f;
        slideCanvasGroup.DOFade(1f, 0.6f).SetEase(Ease.OutCubic).SetUpdate(true);

        Transform[] elements = slide.GetComponentsInChildren<Transform>();
        float delay = 0.2f;
        
        foreach (var element in elements)
        {
            if (element == slide.transform) continue;

            CanvasGroup elementCanvasGroup = element.GetComponent<CanvasGroup>();
            if (elementCanvasGroup == null)
                elementCanvasGroup = element.gameObject.AddComponent<CanvasGroup>();

            elementCanvasGroup.alpha = 0f;
            elementCanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutBack).SetDelay(delay).SetUpdate(true);;
            delay += 0.1f;
        }

        nextStepButton.SetActive(i < slides.Length - 1);
    }

    private bool IsTutorialNeeded()
    {
        return PlayerPrefs.GetInt("Tutorial") == 0;
    }

    public void NextSlide()
    {
        slides[currentStep].SetActive(false);
        if (currentStep < slides.Length - 1)
        {
            currentStep++;
            ShowSlide(currentStep);
        }
    }
    public void CompleteTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();
        Debug.Log("Tutorial complete");

        tutorial.SetActive(false);
        GameManager.Instance.IsPaused = false;  
        GameManager.Instance.StartGame(); 
    }
    
    public void CloseTutorial()
    {
        CompleteTutorial();
    }
}
