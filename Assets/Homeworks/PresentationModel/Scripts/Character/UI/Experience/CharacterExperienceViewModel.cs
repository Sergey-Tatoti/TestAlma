using System;
using UniRx;

public class CharacterExperienceViewModel : ICharacterExperienceViewModel
{
    public int Experience { get; private set; }

    public int MaxExperience { get; private set; }

    public bool IsReachedExperience { get; private set; }

    private readonly CompositeDisposable _disposable = new();

    public event Action OnUpdateData;

    public CharacterExperienceViewModel(Character character)
    {
        Experience = character.CharacterExperience.CurrentExperience.Value;
        MaxExperience = character.CharacterExperience.MaxExperience;

        character.CharacterExperience.CurrentExperience.Subscribe(ChangeExperience).AddTo(_disposable);
        character.CharacterExperience.IsReachedMaxExperience.Subscribe(ChangeReachedExperience).AddTo(_disposable);
    }

    public void Dispose()
    {
        if (_disposable.IsDisposed == false)
        {
            _disposable.Dispose();
        }
    }

    public void ChangeExperience(int experience)
    {
        Experience = experience;
        OnUpdateData?.Invoke();
    }

    public void ChangeReachedExperience(bool isReached)
    {
        IsReachedExperience = isReached;
        OnUpdateData?.Invoke();
    }

    public string GetTextInfoExperience()
    {
        return $"XP: {Experience} / {MaxExperience}";
    }
}