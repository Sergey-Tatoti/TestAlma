using UnityEngine;
using Zenject;

public class HMSceneInstaller : MonoInstaller
{
    [SerializeField] private TestSystem _testSystem;
    [SerializeField] private CharacterPopapView _profileView;

    public override void InstallBindings()
    {
        Container.Bind<TestSystem>().FromInstance(_testSystem).AsSingle();
        Container.Bind<CharacterPopapView>().FromInstance(_profileView).AsSingle();
        //Container.Bind<StatInfoController>().FromInstance(_statInfoController).AsSingle();

        //Container.BindInterfacesTo<GameCycle>().AsSingle();
    }
}