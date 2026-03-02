using UnityEngine;
using Zenject;

public class CameraRoot : MonoBehaviour, IGameTickListener, IGameInitializeListener
{
    [SerializeField] private CameraMovementConfig _movementConfig;
    [SerializeField] private SpriteRenderer _locationSprite;

    private CameraMouseController _mouseController;
    private CameraBoundsController _boundsController;
    private Camera _mainCamera;

    [Inject]
    public void Construct(CameraMouseController mouseController, CameraBoundsController boundsController)
    {
        _mouseController = mouseController;
        _boundsController = boundsController;
        _mainCamera = Camera.main;
    }

    public void Initialize()
    {
        _mouseController.SetValues(_mainCamera, _movementConfig);
        _boundsController.SetBoundsLocation(_locationSprite);
    }

    public void UpdateGame()
    {
        if (GameController.CurrentGameType == GameType.Play)
            _mouseController.HandleMouseInput(_boundsController.LocationBoundsMin, _boundsController.LocationBoundsMax);
    }
}