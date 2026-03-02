using System.Collections.Generic;
using Zenject;

public class PinContoller
{
    private PinCreator _pinCreator;
    private PinInfoController _pinInfoController;
    private CameraMouseController _cameraMouseController;
    private SavePinController _savePinController;

    private readonly HashSet<Pin> _activePins = new();

    public PinCreator PinCreator => _pinCreator;

    [Inject]
    public void Construct(PinCreator pinCreator, PinInfoController pinInfoController, CameraMouseController cameraMouseController, SavePinController savePinController)
    {
        _pinCreator = pinCreator;
        _pinInfoController = pinInfoController;
        _cameraMouseController = cameraMouseController;
        _savePinController = savePinController;
    }

    public void LoadPins(List<PinInfo> infoPins)
    {
        _pinCreator.CreatedPin += OnCreatedPin;
        _cameraMouseController.UsedMove += OnUsedMoveCamera;

        _pinCreator.CreatePins(infoPins);
    }

    private void OnCreatedPin(Pin pin)
    {
        _activePins.Add(pin);
        //_pinInfoController.CreatePinInfo(pin);

        pin.PinToucher.ClickedRemovePin += OnClickedRemovePin;
        pin.PinToucher.ClickedShowPin += OnClickedShowPin;
        pin.PinToucher.UsedMovePin += OnUseedMovePin;
        pin.ChangedPinInfo += OnChangedPinInfo;
    }

    private void OnClickedRemovePin(Pin pin)
    {
        if (_activePins.Remove(pin))
        {
            _pinCreator.AddPinPool(pin);
            _pinInfoController.HidePinInfo();
            _savePinController.RemoveInfoPin(pin.PinInfo);

            pin.PinToucher.ClickedRemovePin -= OnClickedRemovePin;
            pin.PinToucher.ClickedShowPin -= OnClickedShowPin;
            pin.PinToucher.UsedMovePin -= OnUseedMovePin;
            pin.ChangedPinInfo -= OnChangedPinInfo;
        }
    }

    private void OnClickedShowPin(Pin pin) => _pinInfoController.ShowPinInfo(pin);

    private void OnUsedMoveCamera() => _pinInfoController.HidePinInfo();

    private void OnUseedMovePin() => _pinInfoController.HidePinInfo();

    private void OnChangedPinInfo(PinInfo pinInfo) => _savePinController.SaveInfoPin(pinInfo);
}