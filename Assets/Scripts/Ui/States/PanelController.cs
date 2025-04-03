using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : IUIState
{
    private readonly PanelView _view;
    private readonly UISwitcher _uiSwitcher;
    private readonly IFadeService _fadeService;
    private readonly ISoundPlayer _soundPlayer;
    private readonly Score _score;

    public PanelController() { }

    public PanelController(PanelView view, UISwitcher uiSwitcher, IFadeService fadeService,
        ISoundPlayer soundPlayer, ISaver saver)
    {
        _view = view;
        _uiSwitcher = uiSwitcher;
        _fadeService = fadeService;
        _soundPlayer = soundPlayer;
        _score = new Score(saver);
    }

    public void Enter()
    {
        _view.SubscribeClose(OnCloseClicked);
        _view.SubscribeCollect(OnCollectClicked);
        _view.gameObject.SetActive(true);
        _fadeService.FadeIn(_view.GetComponent<Image>(), 0.5f);
        _soundPlayer.PlayOpenSound();
        UpdateScoreText();
    }

    public void Exit()
    {
        _view.UnsubscribeClose(OnCloseClicked);
        _view.UnsubscribeCollect(OnCollectClicked);
        _fadeService.FadeOut(_view.GetComponent<Image>(), 0.5f, () =>
        {
            _view.gameObject.SetActive(false);
        });
        _soundPlayer.PlayCloseSound();
        _score.Save();
    }

    private void OnCloseClicked()
    {
        _uiSwitcher.SwitchState<MainScreenController>();
    }

    private void OnCollectClicked()
    {
        _score.AddScore();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _view.ScoreText.text = $"Score: {_score.GetScore()}";
    }
}