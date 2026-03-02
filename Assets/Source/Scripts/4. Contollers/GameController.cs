using UnityEngine;
using Zenject;

public class GameController : IGameInitializeListener
{
    public static GameType CurrentGameType;

    private PinContoller _pinController;
    private Location _location;

    [Inject]
    public void Construct(PinContoller pinController, Location location)
    {
        _location = location;
        _pinController = pinController;
    }

    public void Initialize()
    {
        _location.Clicked += OnClickedLocation;
    }

    private void OnClickedLocation(Vector3 position) => _pinController.PinCreator.CreatePinOnLocation(position);
}
