using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private CharacterPopapView _characterPopapView;
    [SerializeField] private CharacterInfoView _characterInfoView;
    [SerializeField] private CharacterExperienceView _characterExperienceView;
    [SerializeField] private CharacterStatsView _characterStatsView;
    [SerializeField] private Character _character;

    private List<IViewModel> _viewsModels = new();

    [Button]
    public void ShowInfoCharacter()
    {
        if (_character == null)
            return;

        _characterPopapView.SetInfo(new CharacterPopapViewModel(_character));
        _characterInfoView.SetInfo(new CharacterInfoViewModel(_character));
        _characterExperienceView.SetInfo(new CharacterExperienceViewModel(_character));
        _characterStatsView.SetInfo(new CharacterStatsViewModel(_character));
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
            _characterPopapView.CloseInfoCharacter();
    }
}