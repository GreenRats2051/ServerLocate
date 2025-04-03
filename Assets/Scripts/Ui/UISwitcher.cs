using System;

public class UISwitcher
{
    private IUIState _currentState;
    private readonly IServiceLocator _serviceLocator;

    public UISwitcher(IServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    public void SwitchState<T>() where T : IUIState
    {
        _currentState?.Exit();

        if (_serviceLocator.GetService<T>(out var state))
        {
            _currentState = state;
            _currentState.Enter();
        }
    }
}