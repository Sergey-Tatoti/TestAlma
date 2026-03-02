using System.Collections.Generic;
using Zenject;

public class GameCycle : IInitializable, ITickable
{
    private List<IGameListener> _gameListners;
    private List<IGameInitializeListener> _initializeListners = new();
    private List<IGameTickListener> _tickListeners = new();

    [Inject]
    public void Construct(CameraRoot cameraRoot, GameController gameController, SavePinController savePinContoller, PinInfoController pinInfoController)
    {
        _gameListners = new List<IGameListener>() { cameraRoot, savePinContoller, gameController, pinInfoController };

        for (int i = 0; i < _gameListners.Count; i++)
        {
            AddListener(_gameListners[i]);
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < _initializeListners.Count; i++) { _initializeListners[i].Initialize(); }
    }

    public void Tick()
    {
        for (int i = 0; i < _tickListeners.Count; i++) { _tickListeners[i].UpdateGame(); }
    }

    private void AddListener(IGameListener listener)
    {
        if (listener is IGameInitializeListener awakeListener)
            _initializeListners.Add(awakeListener);

        if (listener is IGameTickListener updateListener)
            _tickListeners.Add(updateListener);
    }
}