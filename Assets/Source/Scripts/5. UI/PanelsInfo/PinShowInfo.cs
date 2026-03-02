using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PinShowInfo : PinPanelInfo
{
    [SerializeField] private Button _buttonRedactor;

    public event UnityAction ClickedCreateInfoLocation;

    public override void ShowPanel(PinInfo pinInfo)
    {
        base.ShowPanel(pinInfo);

        _buttonRedactor.onClick.AddListener(ClickedButtonRedactor);
    }

    public override void HidePanel()
    {
        base.HidePanel();
        _buttonRedactor.onClick.RemoveListener(ClickedButtonRedactor);
    }

    private void ClickedButtonRedactor()
    {
        HidePanel();
        ClickedCreateInfoLocation?.Invoke();
    }
}