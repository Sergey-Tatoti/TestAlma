using Zenject;

public class PinInfoController : IGameInitializeListener
{
    private PinShowInfo _pinShowInfo;
    private PinCreateInfo _pinCreateInfo;
    private PinPrewieInfo _pinPrewieInfo;
    private Pin _activePin;

    [Inject]
    public void Consturct(PinShowInfo pinShowInfo, PinPrewieInfo pinPrewieInfo, PinCreateInfo pinCreateInfo)
    {
        _pinCreateInfo = pinCreateInfo;
        _pinShowInfo = pinShowInfo;
        _pinPrewieInfo = pinPrewieInfo;
    }

    public void Initialize()
    {
        _pinPrewieInfo.ClickedShowInfoLocation += OnClickedShowInfoLocation;
        _pinShowInfo.ClickedCreateInfoLocation += OnClickedCreateInfoLocation;
        _pinShowInfo.ClickedClosePanel += OnClickedClosePanel;
        _pinCreateInfo.ClickedEnterChanges += OnClickedEnterChanges;
        _pinCreateInfo.ClickedClosePanel += OnClickedClosePanel;
    }

    public void ShowPinInfo(Pin pin)
    {
        _activePin = pin;
        _pinPrewieInfo.ShowPanel(_activePin);
    }

    public void CreatePinInfo(Pin pin)
    {
        _activePin = pin;
        ShowPanelInfo(_pinCreateInfo);
    }


    public void HidePinInfo() => _pinPrewieInfo.HidePanel();

    private void OnClickedShowInfoLocation() => ShowPanelInfo(_pinShowInfo);

    private void OnClickedCreateInfoLocation() => ShowPanelInfo(_pinCreateInfo);

    private void OnClickedEnterChanges(PinInfo pinInfo) => _activePin.ChangeInfo(pinInfo);

    private void OnClickedClosePanel() => GameController.CurrentGameType = GameType.Play;

    private void ShowPanelInfo(PinPanelInfo pinPanelInfo)
    {
        GameController.CurrentGameType = GameType.Redact;
        pinPanelInfo.ShowPanel(_activePin.PinInfo);
    }
}