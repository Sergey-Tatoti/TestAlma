using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PinToucher))]

public class Pin : MonoBehaviour
{
    private PinToucher _pinToucher;
    private PinInfo _pinInfo;

    public PinInfo PinInfo => _pinInfo;
    public PinToucher PinToucher => _pinToucher;


    public event UnityAction<PinInfo> ChangedPinInfo;

    public void Initialize()
    {
        _pinToucher = GetComponent<PinToucher>();
        _pinToucher.StopedMovePin += OnStopedMovePin;
    }

    public void SetId(int id) => _pinInfo.Id = id;

    public void ChangeInfo(PinInfo pinInfo, bool isNewInfo = true)
    {
        _pinInfo.Name = pinInfo.Name;
        _pinInfo.Description = pinInfo.Description;
        _pinInfo.PositionX = transform.position.x;
        _pinInfo.PositionY = transform.position.y;

        if (isNewInfo)
            ChangedPinInfo?.Invoke(_pinInfo);
    }

    private void OnStopedMovePin() => ChangeInfo(_pinInfo);
}

public struct PinInfo
{
    public int Id;
    public string Name;
    public string Description;
    public Sprite Sprite;
    public float PositionX;
    public float PositionY;
}