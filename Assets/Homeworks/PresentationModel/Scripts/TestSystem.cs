using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class TestSystem : MonoBehaviour
{
    private Character _character;
    private CharacterViewModel _characterViewModel;

    public event UnityAction<CharacterViewModel> ShowedInfoCharacter;
    public event UnityAction ClosedInfoCharacter;

    [Button]
    public void ShowInfoCharacter(Character character)
    {
        if (character != null)
        {
            _character = character;
            _characterViewModel = new CharacterViewModel(_character);

            ShowedInfoCharacter?.Invoke(_characterViewModel);
        }
    }

    [Button]
    public void IncreaseExperience(int countExperience)
    {
        if (_character != null)
            _character.CharacterExperience.IncreaseExperience(countExperience);
    }

    [Button]
    public void CloseInfoCharacter()
    {
        if (_character != null)
            ClosedInfoCharacter?.Invoke();
    }
}