using DG.Tweening;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 initialScale;
    private Material playerMaterial;
    private Color initialColor;

    public void Start()
    {
        initialScale = transform.localScale;
        playerMaterial = GetComponent<Renderer>().material;
        initialColor = playerMaterial.color;
    }

    public void AttachRope(Vector3 stickyBallPosition)
    {
        Vector2 direction = (stickyBallPosition - transform.position).normalized;
        Vector3 stretch = initialScale + (Vector3)(direction * 0.4f); 

        transform.DOScale(stretch, 0.15f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => transform.DOScale(initialScale, 0.15f).SetEase(Ease.InQuad));
    }
    
    public void Heal()
    {
        transform.DOScale(initialScale * 1.2f, 0.2f).SetEase(Ease.OutQuad)
            .OnComplete(() => transform.DOScale(initialScale, 0.2f).SetEase(Ease.InQuad));
    }

    public void TakeDamage()
    {
        playerMaterial.DOColor(Color.red, 0.5f).OnComplete(() => playerMaterial.DOColor(initialColor, 0.5f));
    }
}