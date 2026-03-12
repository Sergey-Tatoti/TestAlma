using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterExperienceView : MonoBehaviour
{
    [SerializeField] private Image _imageExperienceBar;
    [SerializeField] private TMP_Text _textExperience;
    [SerializeField] private Sprite _spriteBaseProgressBar;
    [SerializeField] private Sprite _spriteCompletedProgressBar;

    public void ChangeExperience(int value, int maxValue)
    {
        ChangeSpriteBar(value >= maxValue);
        ChangeValueBar(value, maxValue);
        ChangeText(value.ToString(), maxValue.ToString());
    }

    public void ChangeSpriteBar(bool isCompleteProgress)
    {
        _imageExperienceBar.sprite = isCompleteProgress ? _spriteCompletedProgressBar : _spriteBaseProgressBar;
    }

    private void ChangeText(string value, string maxValue)
    {
        _textExperience.text = $"XP: {value} / {maxValue}";
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