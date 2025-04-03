using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _openSound;
    [SerializeField] private AudioClip _closeSound;

    private void Awake()
    {
        var serviceLocator = new ServiceLocator();

        serviceLocator.RegisterService<IFadeService>(new FadeService());
        serviceLocator.RegisterService<ISoundPlayer>(new SoundPlayer(_audioSource, _openSound, _closeSound));
        serviceLocator.RegisterService<ISaver>(new PlayerPrefsSaver());

        var mainScreenView = FindObjectOfType<MainScreenView>();
        var panelView = FindObjectOfType<PanelView>();

        var uiSwitcher = new UISwitcher(serviceLocator);

        serviceLocator.RegisterService<MainScreenController>(
            new MainScreenController(mainScreenView, uiSwitcher));

        serviceLocator.RegisterService<PanelController>(new PanelController(panelView, uiSwitcher, serviceLocator.GetService<IFadeService>(out var fadeService) ? fadeService : null, serviceLocator.GetService<ISoundPlayer>(out var soundPlayer) ? soundPlayer : null, serviceLocator.GetService<ISaver>(out var saver) ? saver : null));

        uiSwitcher.SwitchState<MainScreenController>();
    }
}