using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PinCreateInfo : PinPanelInfo
{
    [SerializeField] private Button _buttonEnterChanges;

    private string _currentNameLocation;
    private string _currentDescriptionLocation;
    private Sprite _currentSprite;

    public event UnityAction<PinInfo> ClickedEnterChanges;

    public override void ShowPanel(PinInfo pinInfo)
    {
        base.ShowPanel(pinInfo);

        if (pinInfo.Sprite != null)
            _currentSprite = pinInfo.Sprite;

        _currentNameLocation = pinInfo.Name;
        _currentDescriptionLocation = pinInfo.Description;

        _buttonEnterChanges.onClick.AddListener(ClickedButtonEnterChanges);
    }

    private void ClickedButtonEnterChanges()
    {
        _currentNameLocation = _fieldNameLocation.text;
        _currentDescriptionLocation = _fieldDescription.text;
        _currentSprite = _imageInfo.sprite;

        PinInfo pinInfo = new PinInfo
        {
            Name = _currentNameLocation,
            Description = _currentDescriptionLocation,
            Sprite = _currentSprite,
        };

        HidePanel();

        ClickedEnterChanges?.Invoke(pinInfo);
    }

    public override void HidePanel()
    {
        _fieldNameLocation.text = _currentNameLocation;
        _fieldDescription.text = _currentDescriptionLocation;
        _imageInfo.sprite = _currentSprite;

        base.HidePanel();

        _buttonEnterChanges.onClick.RemoveListener(ClickedButtonEnterChanges);
    }
}
