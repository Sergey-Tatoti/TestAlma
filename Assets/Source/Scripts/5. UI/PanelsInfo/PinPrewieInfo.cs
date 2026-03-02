using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PinPrewieInfo : MonoBehaviour
{
    [SerializeField] private Vector3 _offsetShowPanel;
    [SerializeField] private GameObject _panelInfo;
    [SerializeField] private TMP_Text _textNameLocation;
    [SerializeField] private Button _buttonShowInfoLocation;
    [Space]
    [SerializeField] private Vector2 _startScale;
    [SerializeField] private Vector2 _endScale;
    [SerializeField] private float _durationChangeScale;

    public event UnityAction ClickedShowInfoLocation;

    public void ShowPanel(Pin pin)
    {
        DOTween.Kill(this);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(pin.transform.position);

        _textNameLocation.text = pin.PinInfo.Name;
        _panelInfo.transform.position = screenPos + _offsetShowPanel;
        _panelInfo.transform.localScale = _startScale;
        _panelInfo.gameObject.SetActive(true);
        _panelInfo.transform.DOScale(_endScale, _durationChangeScale);

        _buttonShowInfoLocation.onClick.AddListener(ClickedButtonShowInfoLocation);
    }

    public void HidePanel()
    {
        DOTween.Kill(this);

        _panelInfo.gameObject.SetActive(false);
        _buttonShowInfoLocation.onClick.RemoveListener(ClickedButtonShowInfoLocation);
    }

    private void ClickedButtonShowInfoLocation()
    {
        HidePanel();
        ClickedShowInfoLocation?.Invoke();
    }
}