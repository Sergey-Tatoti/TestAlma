using System;
using UniRx;
using UnityEngine;

public sealed class LevelUper
{
    public IReadOnlyReactiveProperty<int> Level => _level;
    private readonly ReactiveProperty<int> _level = new ReactiveProperty<int>();

    private readonly Character _character;
    private readonly IDisposable _disposable;

    public LevelUper(Character character)
    {
        _character = character;
        _disposable = _character.CharacterExperience.Level.Subscribe(OnLevelChange);
    }

    private void OnLevelChange(int level)
    {
        _level.SetValueAndForceNotify(level);
    }

    public void LevelUp(Character character)
    {
        if (CanLevelUp(character))
        {
           // _moneyStorage.SpendMoney(product.MoneyPrice);
            Debug.Log($"<color=green>Product {character.Name} successfully purchased!</color>");
        }
        else
        {
            Debug.LogWarning($"<color=red>Not enough money for product {character.Name}!</color>");
        }
    }

    public bool CanLevelUp(Character character)
    {
        return character.CharacterExperience.CurrentExperience.Value >= character.CharacterExperience.MaxExperience;
    }

    ~LevelUper()
    {
        _disposable.Dispose();
    }
}