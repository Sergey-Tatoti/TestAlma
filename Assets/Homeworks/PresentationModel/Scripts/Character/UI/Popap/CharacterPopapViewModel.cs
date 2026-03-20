using System;
using System.Collections.Generic;
using UniRx;

public class CharacterPopapViewModel : ICharacterPopapViewModel
{
    public bool CanLevelUp { get; private set; }

    private readonly Character _character;
    private readonly CompositeDisposable _disposable = new();

    public event Action OnUpdateData;

    public CharacterPopapViewModel(Character character)
    {
        _character = character;

        _character.CharacterExperience.IsReachedMaxExperience.Subscribe(ChangeCanLevelUp).AddTo(_disposable);
    }

    public void Dispose()
    {
        if (_disposable.IsDisposed == false)
        {
            _disposable.Dispose();
        }
    }

    public void LevelUp() => _character.LevelUp();

    public void ChangeCanLevelUp(bool canLevelUp)
    {
        CanLevelUp = canLevelUp;
        OnUpdateData?.Invoke();
    }
}