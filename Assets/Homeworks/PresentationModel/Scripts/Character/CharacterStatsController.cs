using System.Collections.Generic;
using UniRx;

public class CharacterStatsController
{
    public IReadOnlyReactiveProperty<List<CharacterStat>> Stats => _stats;
    private readonly ReactiveProperty<List<CharacterStat>> _stats = new();

    public CharacterStatsController(List<CharacterStat> initialStats)
    {
        _stats = new ReactiveProperty<List<CharacterStat>>(initialStats);
    }

    public void IncreaseStats()
    {
        List<CharacterStat> currentStats = _stats.Value;

        for (int i = 0; i < currentStats.Count; i++)
        {
            currentStats[i].ChangeValue(currentStats[i].Value + 1);
        }

        _stats.Value = new List<CharacterStat>(currentStats);
    }
}