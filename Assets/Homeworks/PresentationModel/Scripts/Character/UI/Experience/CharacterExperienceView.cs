using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterExperienceView : MonoBehaviour, ICharacterView, IDisposable
{
    [SerializeField] private Image _imageExperienceBar;
    [SerializeField] private TMP_Text _textExperience;
    [SerializeField] private Sprite _spriteBaseProgressBar;
    [SerializeField] private Sprite _spriteCompletedProgressBar;

    private ICharacterExperienceViewModel _viewModel;

    public void Dispose()
    {
        _viewModel.OnUpdateData -= UpdatedData;
    }

    public void SetInfo(IViewModel viewModel)
    {
        if (viewModel is not ICharacterExperienceViewModel characterExperienceViewModel)
            throw new Exception("Not type IViewModel");

        _viewModel = characterExperienceViewModel;

        _viewModel.OnUpdateData += UpdatedData;
        UpdatedData();
    }

    public void UpdatedData()
    {
        ChangeSpriteBar(_viewModel.IsReachedExperience);
        ChangeValueBar(_viewModel.Experience, _viewModel.MaxExperience);
        ChangeText();
    }

    private void ChangeSpriteBar(bool isCompleteProgress)
    {
        _imageExperienceBar.sprite = isCompleteProgress ? _spriteCompletedProgressBar : _spriteBaseProgressBar;
    }

    private void ChangeText()
    {
        _textExperience.text = _viewModel.GetTextInfoExperience();
    }

    private void ChangeValueBar(int value, int maxValue)
    {
        float valueFillAmount = (float)value / maxValue;

        if (valueFillAmount > 1)
            _imageExperienceBar.fillAmount = 1;
        else
            _imageExperienceBar.fillAmount = valueFillAmount;
    }
}