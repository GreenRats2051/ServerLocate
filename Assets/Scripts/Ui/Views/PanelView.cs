using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Button _collectButton;

    public Button CloseButton => _closeButton;
    public Text ScoreText => _scoreText;
    public Button CollectButton => _collectButton;

    public void SubscribeClose(Action onCloseClicked)
    {
        _closeButton.onClick.AddListener(() => onCloseClicked?.Invoke());
    }

    public void UnsubscribeClose(Action onCloseClicked)
    {
        _closeButton.onClick.RemoveListener(() => onCloseClicked?.Invoke());
    }

    public void SubscribeCollect(Action onCollectClicked)
    {
        _collectButton.onClick.AddListener(() => onCollectClicked?.Invoke());
    }

    public void UnsubscribeCollect(Action onCollectClicked)
    {
        _collectButton.onClick.RemoveListener(() => onCollectClicked?.Invoke());
    }
}