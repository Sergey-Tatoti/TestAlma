using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PinToucher : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerExitHandler
{
    [SerializeField] private float _longPressDuration = 0.5f;
    [SerializeField] private Vector3 _offsetCursor;

    private bool _isClamp;
    private Coroutine _coroutineTryMove;

    public event UnityAction<Pin> ClickedRemovePin;
    public event UnityAction<Pin> ClickedShowPin;
    public event UnityAction UsedMovePin;
    public event UnityAction StopedMovePin;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            ClickedRemovePin?.Invoke(GetComponent<Pin>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _coroutineTryMove = StartCoroutine(TryMove());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isClamp)
            ClickedShowPin?.Invoke(GetComponent<Pin>());
        else
            StopedMovePin?.Invoke();

        if (_coroutineTryMove != null)
            StopCoroutine(_coroutineTryMove);

        _isClamp = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isClamp)
        {
            Vector3 cursorScreenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.WorldToScreenPoint(transform.position).z);
            Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + _offsetCursor;
            transform.position = new Vector3(cursorWorldPos.x, cursorWorldPos.y, 0);

            UsedMovePin?.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_coroutineTryMove != null)
            StopCoroutine(_coroutineTryMove);
    }

    private IEnumerator TryMove()
    {
        yield return new WaitForSeconds(_longPressDuration);

        _isClamp = true;
    }
}
