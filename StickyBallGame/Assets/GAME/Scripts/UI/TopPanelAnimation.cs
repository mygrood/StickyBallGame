using System;
using DG.Tweening;
using UnityEngine;

public class TopPanelAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform panelRectTransform; 
    [SerializeField] private float animationDuration = 0.5f;  
    [SerializeField] private float hideOffset = 500f;       

    private Vector2 originalPosition; 
    private bool isPanelOpen = false;  
    public bool IsOpen => isPanelOpen; 

    private void Awake()
    {
        panelRectTransform=GetComponent<RectTransform>();
        gameObject.SetActive(false);
        originalPosition = panelRectTransform.anchoredPosition;
        panelRectTransform.anchoredPosition = originalPosition + new Vector2(0, hideOffset);
    }

    public void Open()
    {
        if (!isPanelOpen)
        {
            gameObject.SetActive(true);

            panelRectTransform.DOAnchorPos(originalPosition, animationDuration).SetEase(Ease.OutBack)
                .OnComplete(() => isPanelOpen = true); 
        }
    }

    public void Close()
    {
        if (isPanelOpen)
        {
            panelRectTransform.DOAnchorPos(originalPosition + new Vector2(0, hideOffset), animationDuration)
                .SetEase(Ease.InBack)
                .OnComplete(() => 
                {
                    gameObject.SetActive(false); 
                    isPanelOpen = false;  
                });
        }
    }
}