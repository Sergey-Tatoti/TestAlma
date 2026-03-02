using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Location : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<Vector3> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);

            worldPoint.z = transform.position.z;

            Clicked?.Invoke(worldPoint);
        }
    }
}