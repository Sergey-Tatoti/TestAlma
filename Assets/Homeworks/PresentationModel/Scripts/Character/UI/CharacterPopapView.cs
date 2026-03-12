using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterPopapView : MonoBehaviour, IDisposable
{
    [SerializeField] private CharacterInfoView _characterInfoView;
    [SerializeField] private CharacterExperienceView _experienceView;
    [SerializeField] private StatInfoController _statInfoController;
    [Space]
    [SerializeField] private GameObject _panelProfile;
    [SerializeField] private Button _buttonLevelUp;
    [SerializeField] private Button _buttonExit;

    private TestSystem _testSystem;
    private ICharacterViewModel _viewModel;

    [Inject]
    public void Construct(TestSystem testSystem)
    {
        _testSystem = testSystem;

        _testSystem.ShowedInfoCharacter += OnShowedInfoCharacter;
        _testSystem.ClosedInfoCharacter += OnClosedInfoCharacter;
        _buttonLevelUp.onClick.AddListener(ClickedButtonLevelUp);
        _buttonExit.onClick.AddListener(OnClosedInfoCharacter);

        _statInfoController.Initialize();
        _panelProfile.gameObject.SetActive(false);
    }

    public void Dispose()
    {
        _testSystem.ShowedInfoCharacter -= OnShowedInfoCharacter;
        _testSystem.ClosedInfoCharacter -= OnClosedInfoCharacter;

        _buttonLevelUp.onClick.RemoveListener(ClickedButtonLevelUp);
        _buttonExit.onClick.RemoveListener(OnClosedInfoCharacter);
    }

    private void OnShowedInfoCharacter(IViewModel viewModel)
    {
        if (viewModel is not ICharacterViewModel characterViewModel)
            throw new Exception("Invalid view model type");

        _viewModel = characterViewModel;

        _viewModel.OnUpdateData += OnUpdateData;

        _panelProfile.gameObject.SetActive(true);
        _characterInfoView.SetInfo(_viewModel.Name, _viewModel.Description, _viewModel.SpriteAvatar);
        OnUpdateData();
    }

    private void OnClosedInfoCharacter()
    {
        _viewModel.OnUpdateData -= OnUpdateData;
        _viewModel.Dispose();
    }

    private void OnUpdateData()
    {
        OnChangedLevel(_viewModel.Level);
        OnChangedExperience(_viewModel.Experience, _viewModel.MaxExperience);
        OnChangedStats(_viewModel.Stats);

        _buttonLevelUp.interactable = _viewModel.CanLevelUp;
        _experienceView.ChangeSpriteBar(_viewModel.CanLevelUp);
    }

    private void ClickedButtonLevelUp()
    {
        if(_viewModel.CanLevelUp)
            _viewModel.LevelUp();
    }

    private void OnChangedLevel(string level) => _characterInfoView.ChangeLevel(level);

    private void OnChangedExperience(int experience, int maxExperience) => _experienceView.ChangeExperience(experience, maxExperience);

    private void OnChangedStats(List<CharacterStat> characterStats) => _statInfoController.ChangeStatsInfo(characterStats);
}