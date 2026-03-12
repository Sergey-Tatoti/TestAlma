using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class CharacterViewModel : ICharacterViewModel
{
    public string Name { get; }
    public string Description { get; }
    public Sprite SpriteAvatar { get; }
    public int MaxExperience { get; }
    public string Level { get; private set; }
    public bool CanLevelUp { get; private set; }
    public List<CharacterStat> Stats { get; private set; }
    public int Experience { get; private set; }

    private readonly Character _character;
    private readonly CompositeDisposable _disposable = new();

    public IReadOnlyReactiveProperty<bool> CanLevelUpReactive => _canLevelUp;
    private readonly ReactiveProperty<bool> _canLevelUp = new();

    public ReactiveCommand LevelUpCommand { get; }

    public event UnityAction OnUpdateData;

    public CharacterViewModel(Character character)
    {
        _character = character;

        Name = _character.Name;
        Description = _character.Description;
        SpriteAvatar = _character.SpriteAvatar;
        MaxExperience = _character.CharacterExperience.MaxExperience;

        _character.CharacterExperience.Level.Subscribe(OnLevelChanged).AddTo(_disposable);
        _character.CharacterExperience.CurrentExperience.Subscribe(OnExperienceChanged).AddTo(_disposable);
        _character.CharacterStats.Stats.Subscribe(OnStatsChanged).AddTo(_disposable);

        LevelUpCommand = new ReactiveCommand(CanLevelUpReactive);
        LevelUpCommand.Subscribe(OnLevelUpCommand).AddTo(_disposable);

        CanLevelUpUpdate();
    }

    public void LevelUp() => _character.LevelUp();

    private void OnLevelUpCommand(Unit obj) => LevelUp();

    private void OnExperienceChanged(int experience)
    {
        Experience = experience;
        CanLevelUpUpdate();
    }

    private void OnStatsChanged(List<CharacterStat> stats)
    {
        Stats = stats;
        OnUpdateData?.Invoke();
    }

    private void OnLevelChanged(int level)
    {
        Level = level.ToString();
        OnUpdateData?.Invoke();
    }

    private void CanLevelUpUpdate()
    {
        CanLevelUp = _character.CharacterExperience.IsReachedMaxExperience;
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