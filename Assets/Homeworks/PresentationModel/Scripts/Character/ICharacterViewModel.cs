using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public interface ICharacterViewModel : IViewModel, IDisposable
{
    string Name { get; }
    string Description { get; }
    Sprite SpriteAvatar { get; }
    string Level { get; }
    int Experience { get; }
    int MaxExperience { get; }
    bool CanLevelUp { get; }
    List<CharacterStat> Stats { get; }

    event UnityAction OnUpdateData;

    IReadOnlyReactiveProperty<bool> CanLevelUpReactive { get; }
    ReactiveCommand LevelUpCommand { get; }

    void LevelUp();
}