using System;
using System.Collections.Generic;
using UniRx;

public class CharacterStatsViewModel : ICharacterStatsViewModel
{
    public List<CharacterStat> Stats { get; private set; }

    private readonly CompositeDisposable _disposable = new();

    public event Action OnUpdateData;

    public CharacterStatsViewModel(Character character)
    {
        character.CharacterStats.Stats.Subscribe(ChangeStats).AddTo(_disposable);
    }

    public void ChangeStats(List<CharacterStat> stats)
    {
        Stats = stats;
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
