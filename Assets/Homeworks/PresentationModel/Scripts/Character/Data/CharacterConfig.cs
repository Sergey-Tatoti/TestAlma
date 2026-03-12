using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Create/CharacterConfig", order = -51)]
public class CharacterConfig : ScriptableObject
{
    [Header("Info:")]
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] [TextArea(3, 5)] private int _startLevel;
    [SerializeField] private Sprite _spriteAvatar;

    [Header("StatsArgs:")]
    [SerializeField] private List<CharacterStat> _characterStats;

    public string Name => _name;
    public string Description => _description;
    public int StartLevel => _startLevel;
    public Sprite SpriteAvatar => _spriteAvatar;
    public List<CharacterStat> CharacterStats => new List<CharacterStat>(_characterStats);
}

[Serializable]
public class CharacterStat
{
    [SerializeField] private string _name;
    [SerializeField] private TypeStat _type;
    [SerializeField] private int _value;

    public int Value => _value;
    public TypeStat Type => _type;
    public string Name => _name;

    public void ChangeValue(int value) => _value = value;
}