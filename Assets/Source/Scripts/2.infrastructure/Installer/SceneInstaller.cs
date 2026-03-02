using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private CameraRoot _cameraRoot;
    [SerializeField] private Location _location;
    [SerializeField] private PinCreator _pinCreator;
    [SerializeField] private PinShowInfo _pinShowInfo;
    [SerializeField] private PinCreateInfo _pinCreateInfo;
    [SerializeField] private PinPrewieInfo _pinPrewieInfo;

    public override void InstallBindings()
    {
        Container.Bind<CameraRoot>().FromInstance(_cameraRoot).AsSingle();
        Container.Bind<Location>().FromInstance(_location).AsSingle();
        Container.Bind<PinCreator>().FromInstance(_pinCreator).AsSingle();
        Container.Bind<PinShowInfo>().FromInstance(_pinShowInfo).AsSingle();
        Container.Bind<PinCreateInfo>().FromInstance(_pinCreateInfo).AsSingle();
        Container.Bind<PinPrewieInfo>().FromInstance(_pinPrewieInfo).AsSingle();

        Container.Bind<SavePinController>().AsSingle();
        Container.Bind<CameraBoundsController>().AsSingle();
        Container.Bind<CameraMouseController>().AsSingle();
        Container.Bind<GameController>().AsSingle();
        Container.Bind<PinContoller>().AsSingle();
        Container.Bind<PinInfoController>().AsSingle();

        Container.BindInterfacesTo<GameCycle>().AsSingle();
    }
}