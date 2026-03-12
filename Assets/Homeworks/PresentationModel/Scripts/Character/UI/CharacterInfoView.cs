using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private TMP_Text _textDescription;
    [SerializeField] private Image _imageAvatar;

    public void SetInfo(string name, string description, Sprite spriteAvatar)
    {
        _textName.text = name;
        _textDescription.text = description;
        _imageAvatar.sprite = spriteAvatar;
    }

    public void ChangeLevel(string level)
    {
        _textLevel.text = "Level: " + level;
    }
}