using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CameraMouseController
{
    private bool _isDragging;
    private Vector3 _dragOrigin;
    private Camera _mainCamera;
    private CameraMovementConfig _movementConfig;

    public event UnityAction UsedMove;

    public void SetValues(Camera mainCamera, CameraMovementConfig movementConfig)
    {
        _mainCamera = mainCamera;
        _movementConfig = movementConfig;
    }

    public void HandleMouseInput(Vector2 locationBoundsMin, Vector2 locationBoundsMax)
    {
        TryActivateDrag();
        TryMoveCamera(locationBoundsMin, locationBoundsMax);
        TryUseScrolling();
    }

    private void TryActivateDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _dragOrigin = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _isDragging = true;
            _mainCamera.transform.DOKill();
        }

        if (Input.GetMouseButtonUp(1))
            _isDragging = false;
    }

    private void TryUseScrolling()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

        if (scrollDelta != 0)
        {
            float newSize = _mainCamera.orthographicSize - scrollDelta * _movementConfig.ZoomSpeed;

            newSize = Mathf.Clamp(newSize, _movementConfig.MinZoom, _movementConfig.MaxZoom);
            _mainCamera.DOOrthoSize(newSize, _movementConfig.DurationZoom).SetEase(Ease.OutQuad);
        }
    }

    private void TryMoveCamera(Vector2 locationBoundsMin, Vector2 locationBoundsMax)
    {
        if (Input.GetMouseButton(1) && _isDragging)
        {
            Vector3 currentPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 moveDirection = _dragOrigin - currentPos;
            Vector3 newCameraPosition = _mainCamera.transform.position + moveDirection * _movementConfig.MoveSpeedCamera * Time.deltaTime;

            newCameraPosition = GetClampCameraPosition(newCameraPosition, locationBoundsMin, locationBoundsMax);
            _mainCamera.transform.DOMove(newCameraPosition, _movementConfig.MoveEaseDurationCamera).SetEase(_movementConfig.TypeEaseCamera);

            if (moveDirection != Vector3.zero)
                UsedMove?.Invoke();
        }
    }

    private Vector3 GetClampCameraPosition(Vector3 targetPosition, Vector2 locationBoundsMin, Vector2 locationBoundsMax)
    {
        float cameraHeight = _mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * _mainCamera.aspect;

        float halfCameraWidth = cameraWidth / 2f;
        float halfCameraHeight = cameraHeight / 2f;

        float minX = locationBoundsMin.x + halfCameraWidth;
        float maxX = locationBoundsMax.x - halfCameraWidth;
        float minY = locationBoundsMin.y + halfCameraHeight;
        float maxY = locationBoundsMax.y - halfCameraHeight;

        minX = Mathf.Min(minX, maxX);
        minY = Mathf.Min(minY, maxY);

        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(clampedX, clampedY, targetPosition.z);
    }
}