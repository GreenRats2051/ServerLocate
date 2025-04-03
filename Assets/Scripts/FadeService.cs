using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FadeService : IFadeService
{
    public void FadeIn(Image image, float duration)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        image.DOFade(1f, duration);
    }

    public void FadeOut(Image image, float duration, Action onComplete = null)
    {
        image.DOFade(0f, duration).OnComplete(() => onComplete?.Invoke());
    }
}