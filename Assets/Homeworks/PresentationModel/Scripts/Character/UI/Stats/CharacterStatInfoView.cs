using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class CharacterStatInfoView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textStatInfo;

    private string _nameStat;

    [ShowInInspector, ReadOnly] 
    public TypeStat TypeStat { get; private set; }

    public void FillView(CharacterStat characterStat)
    {
        _nameStat = characterStat.Name;
        TypeStat = characterStat.Type;

        ChangeValue(characterStat.Value);
    }

    public void ChangeValue(int value) => _textStatInfo.text = $"{_nameStat}: {value}";
}