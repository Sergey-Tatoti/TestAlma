using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour, IDisposable, ICharacterView
{
    [SerializeField] private int _countViewsInitialize = 6;
    [SerializeField] private CharacterStatInfoView _statInfoViewPrefab;
    [SerializeField] private Transform _conteiner;

    private readonly List<CharacterStatInfoView> statsInfo = new();
    private ICharacterStatsViewModel _viewModel;

    private void Awake()
    {
        CreateStatInfoView(_countViewsInitialize);
    }

    public void Dispose()
    {
        _viewModel.OnUpdateData -= UpdatedData;
    }

    public void SetInfo(IViewModel viewModel)
    {
        if (viewModel is not ICharacterStatsViewModel characterStatsViewModel)
            throw new Exception("Not type IViewModel");

        _viewModel = characterStatsViewModel;

        _viewModel.OnUpdateData += UpdatedData;

        UpdatedData();
    }

    public void UpdatedData()
    {
        TryExpandStatsInfo(_viewModel.Stats.Count);
        ChangeStatsInfo();
    }

    public void ChangeStatsInfo()
    {
        for (int i = 0; i < statsInfo.Count; i++)
        {
            statsInfo[i].FillView(_viewModel.Stats[i]);
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