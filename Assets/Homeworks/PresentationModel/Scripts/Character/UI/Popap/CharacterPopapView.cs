using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPopapView : MonoBehaviour, ICharacterView, IDisposable
{
    [SerializeField] private GameObject _panelProfile;
    [SerializeField] private Button _buttonLevelUp;
    [SerializeField] private Button _buttonExit;

    private ICharacterPopapViewModel _viewModel;

    private void Awake()
    {
        _buttonLevelUp.onClick.AddListener(ClickedButtonLevelUp);
        _buttonExit.onClick.AddListener(CloseInfoCharacter);

        _panelProfile.gameObject.SetActive(false);
    }

    public void Dispose()
    {
        _buttonLevelUp.onClick.RemoveListener(ClickedButtonLevelUp);
        _buttonExit.onClick.RemoveListener(CloseInfoCharacter);
        _viewModel.OnUpdateData -= UpdatedData;
    }

    public void SetInfo(IViewModel viewModel)
    {
        if (viewModel is not ICharacterPopapViewModel characterPopapViewModel)
            throw new Exception("Not type IViewModel");

        _viewModel = characterPopapViewModel;

        _viewModel.OnUpdateData += UpdatedData;

        _panelProfile.gameObject.SetActive(true);
        UpdatedData();
    }

    public void CloseInfoCharacter()
    {
        _viewModel.OnUpdateData -= UpdatedData;
        _viewModel.Dispose();
    }

    public void UpdatedData()
    {
        _buttonLevelUp.interactable = _viewModel.CanLevelUp;
    }

    private void ClickedButtonLevelUp()
    {
        if(_viewModel.CanLevelUp)
            _viewModel.LevelUp();
    }
}