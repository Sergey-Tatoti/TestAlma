using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoView : MonoBehaviour, ICharacterView, IDisposable
{
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private TMP_Text _textDescription;
    [SerializeField] private Image _imageAvatar;

    private ICharacterInfoViewModel _viewModel;

    public void Dispose()
    {
        _viewModel.OnUpdateData -= UpdatedData;
    }

    public void SetInfo(IViewModel viewModel)
    {
        if (viewModel is not ICharacterInfoViewModel characterInfoViewModel)
            throw new Exception("Not type IViewModel");

        _viewModel = characterInfoViewModel;

        _viewModel.OnUpdateData += UpdatedData;

        UpdatedData();
    }

    public void UpdatedData()
    {
        _textName.text = _viewModel.Name;
        _textDescription.text = _viewModel.Description;
        _imageAvatar.sprite = _viewModel.SpriteAvatar;
        _textLevel.text = _viewModel.Level;
    }
}