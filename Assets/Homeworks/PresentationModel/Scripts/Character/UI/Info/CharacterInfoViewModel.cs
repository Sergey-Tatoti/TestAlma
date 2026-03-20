using System;
using UniRx;
using UnityEngine;

public class CharacterInfoViewModel : ICharacterInfoViewModel
{
    public string Name { get; }
    public string Description { get; }
    public Sprite SpriteAvatar { get; }
    public string Level { get; private set; }

    private readonly CompositeDisposable _disposable = new();

    public event Action OnUpdateData;

    public CharacterInfoViewModel(Character character)
    {
        Name = character.Name;
        Description = character.Description;
        SpriteAvatar = character.SpriteAvatar;

        character.CharacterExperience.Level.Subscribe(ChangeLevel).AddTo(_disposable);
    }

    public void ChangeLevel(int level)
    {
        Level = "Level: " + level;
        OnUpdateData?.Invoke();
    }

    public void Dispose()
    {
        if (_disposable.IsDisposed == false)
        {
            _disposable.Dispose();
        }
    }
}
