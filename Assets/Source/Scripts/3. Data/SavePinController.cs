using Zenject;

public class SavePinController : IGameInitializeListener
{
    private const string SaveKey = "PinSave";

    private PinContoller _pinContoller;
    private SaveData.PinData _data;

    [Inject]
    public void Cunstruct(PinContoller pinController) => _pinContoller = pinController;

    public void Initialize()
    {
        _data = SaveManager.Load<SaveData.PinData>(SaveKey);

        _pinContoller.LoadPins(_data.GetAllInfoPins());
    }

    public void SaveInfoPin(PinInfo pinInfo) => SaveManager.Save(SaveKey, GetSaveInfoPinSnapshot(pinInfo));

    public void RemoveInfoPin(PinInfo pinInfo) => SaveManager.Save(SaveKey, GetRemoveInfoPinSnapshot(pinInfo));

    SaveData.PinData GetRemoveInfoPinSnapshot(PinInfo pinInfo)
    {
        int index = _data.GetIndexByPinInfo(pinInfo);

        _data.Id.RemoveAt(index);
        _data.Name.RemoveAt(index);
        _data.Description.RemoveAt(index);
        _data.PositionX.RemoveAt(index);
        _data.PositionY.RemoveAt(index);

        return _data;
    }

    SaveData.PinData GetSaveInfoPinSnapshot(PinInfo pinInfo)
    {
        if (_data.HasPinInfoById(pinInfo.Id))
            ChangeInfoCurrentData(pinInfo);
        else
            CreateNewInfoData(pinInfo);

        return _data;
    }

    private void ChangeInfoCurrentData(PinInfo pinInfo)
    {
        int index = _data.GetIndexByPinInfo(pinInfo);

        _data.Name[index] = pinInfo.Name;
        _data.Description[index] = pinInfo.Description;
        _data.PositionX[index] = pinInfo.PositionX;
        _data.PositionY[index] = pinInfo.PositionY;
    }

    private void CreateNewInfoData(PinInfo pinInfo)
    {
        _data.Id.Add(pinInfo.Id);
        _data.Name.Add(pinInfo.Name);
        _data.Description.Add(pinInfo.Description);
        _data.PositionX.Add(pinInfo.PositionX);
        _data.PositionY.Add(pinInfo.PositionY);
    }
}