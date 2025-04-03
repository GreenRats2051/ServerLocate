using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenView : MonoBehaviour
{
    [SerializeField] private Button _openButton;

    public Button OpenButton => _openButton;

    public void Subscribe(Action onOpenClicked)
    {
        _openButton.onClick.AddListener(() => onOpenClicked?.Invoke());
    }

    public void Unsubscribe(Action onOpenClicked)
    {
        _openButton.onClick.RemoveListener(() => onOpenClicked?.Invoke());
    }
}