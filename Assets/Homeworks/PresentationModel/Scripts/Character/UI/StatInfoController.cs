using System.Collections.Generic;
using UnityEngine;

public class StatInfoController : MonoBehaviour
{
    [SerializeField] private int _countViewsInitialize = 6;
    [SerializeField] private CharacterStatInfoView _statInfoViewPrefab;
    [SerializeField] private Transform _conteiner;

    private List<CharacterStatInfoView> statsInfo = new List<CharacterStatInfoView>();

    public void Initialize()
    {
        CreateStatInfoView(_countViewsInitialize);
    }

    public void ChangeStatsInfo(List<CharacterStat> characterStats)
    {
        TryExpandStatsInfo(characterStats.Count);

        for (int i = 0; i < statsInfo.Count; i++)
        {
            statsInfo[i].FillView(characterStats[i]);
        }
    }

    private void TryExpandStatsInfo(int countStats)
    {
        if (statsInfo.Count < countStats)
            CreateStatInfoView(statsInfo.Count - countStats);
    }

    private void CreateStatInfoView(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CharacterStatInfoView statInfoView = Instantiate(_statInfoViewPrefab, _conteiner);
            statsInfo.Add(statInfoView);
        }
    }
}