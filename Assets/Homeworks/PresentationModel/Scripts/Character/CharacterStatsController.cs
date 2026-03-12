using System.Collections.Generic;
using UniRx;

public class CharacterStatsController
{
    public IReadOnlyReactiveProperty<List<CharacterStat>> Stats => _stats;
    private readonly ReactiveProperty<List<CharacterStat>> _stats = new();

    public CharacterStatsController(List<CharacterStat> CharacterStat)
    {
        _stats.Value = CharacterStat;
    }

    public void IncreaseStats()
    {
        for (int i = 0; i < Stats.Value.Count; i++)
        {
            Stats.Value[i].ChangeValue(Stats.Value[i].Value + 1);
        }
    }
}