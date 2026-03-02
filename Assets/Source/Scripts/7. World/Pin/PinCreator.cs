using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinCreator : MonoBehaviour
{
    [SerializeField] private int _initializeCount;
    [Space][SerializeField] private Pin _prefabPin;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Transform _locationTransform;

    private readonly Queue<Pin> _pinPool = new();

    public event UnityAction<Pin> CreatedPin;

    public void CreatePins(List<PinInfo> infoPins)
    {
        CreatePoolPins(_initializeCount + infoPins.Count);
        FillLoadingPins(infoPins);
    }

    public void CreatePinOnLocation(Vector3 position)
    {
        Pin pin = GetFreePin();

        CreatedPin?.Invoke(pin);

        pin.transform.position = position;
        pin.ChangeInfo(new PinInfo());
    }

    public void AddPinPool(Pin pin)
    {
        pin.transform.SetParent(_conteiner);
        _pinPool.Enqueue(pin);
    }

    private void CreatePoolPins(int countPoins)
    {
        for (int i = 0; i < countPoins; i++)
        {
            Pin pin = GetCreatingPin(_conteiner);
            pin.SetId(pin.GetInstanceID());
        }
    }

    private void FillLoadingPins(List<PinInfo> infoPins)
    {
        for (int i = 0; i < infoPins.Count; i++)
        {
            Pin pin = GetFreePin();
            pin.transform.position = new Vector3(infoPins[i].PositionX, infoPins[i].PositionY, 0);

            pin.SetId(infoPins[i].Id);
            pin.ChangeInfo(infoPins[i], false);

            CreatedPin?.Invoke(pin);
        }
    }

    private Pin GetCreatingPin(Transform place)
    {
        Pin pin = Instantiate(_prefabPin, place);
        pin.Initialize();

        _pinPool.Enqueue(pin);
        return pin;
    }

    private Pin GetFreePin()
    {
        if (_pinPool.TryDequeue(out var pin))
            pin.transform.SetParent(_locationTransform);
        else
            pin = GetCreatingPin(_locationTransform);

        return pin;
    }
}