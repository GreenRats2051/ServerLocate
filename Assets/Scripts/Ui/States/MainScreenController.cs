using System;

public class MainScreenController : IUIState
{
    private readonly MainScreenView _view;
    private readonly UISwitcher _uiSwitcher;

    public MainScreenController() { }

    public MainScreenController(MainScreenView view, UISwitcher uiSwitcher)
    {
        _view = view;
        _uiSwitcher = uiSwitcher;
    }

    public void Enter()
    {
        _view.Subscribe(OnOpenClicked);
        _view.gameObject.SetActive(true);
    }

    public void Exit()
    {
        _view.Unsubscribe(OnOpenClicked);
        _view.gameObject.SetActive(false);
    }

    private void OnOpenClicked()
    {
        _uiSwitcher.SwitchState<PanelController>();
    }
}