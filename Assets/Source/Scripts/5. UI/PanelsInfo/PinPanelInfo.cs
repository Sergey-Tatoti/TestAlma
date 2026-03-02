using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class PinPanelInfo : MonoBehaviour
{
    [SerializeField] protected GameObject _panelInfo;
    [SerializeField] protected TMP_InputField _fieldDescription;
    [SerializeField] protected TMP_InputField _fieldNameLocation;
    [SerializeField] protected Image _imageInfo;
    [SerializeField] protected Button _buttonClosePanel;

    public event UnityAction ClickedClosePanel;

    public virtual void ShowPanel(PinInfo pinInfo)
    {
        if (pinInfo.Sprite != null)
            _imageInfo.sprite = pinInfo.Sprite;

        _fieldNameLocation.text = pinInfo.Name;
        _fieldDescription.text = pinInfo.Description;
        _panelInfo.gameObject.SetActive(true);

        _buttonClosePanel.onClick.AddListener(ClickedButtonClosePanel);
    }

    public virtual void HidePanel()
    {
        _panelInfo.gameObject.SetActive(false);
        _buttonClosePanel.onClick.RemoveListener(ClickedButtonClosePanel);
    }

    private void ClickedButtonClosePanel()
    {
        HidePanel();

        ClickedClosePanel?.Invoke();
    }
}