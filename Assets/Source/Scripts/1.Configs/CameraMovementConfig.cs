using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraMovementConfig", menuName = "Create/CameraMovementConfig", order = -51)]

public class CameraMovementConfig : ScriptableObject
{
    [Header("Настройка движения по локации")]
    [Tooltip("Скорость движения")][SerializeField] private float _moveSpeedCamera = 60f;
    [Tooltip("Длительность затухания")][SerializeField] private float _moveEaseDurationCamera = 0.6f;
    [Tooltip("Тип затухания")][SerializeField] private Ease _typeEaseCamera = Ease.OutQuad;
    [Space]
    [Tooltip("Скорость увеличения локации")][SerializeField] private float _zoomSpeed = 2f;
    [Tooltip("Продолжительность увеличения")][SerializeField] private float _durationZoom = 0.6f;
    [Tooltip("Мин масштаб")][SerializeField] private float _minZoom = 3f;
    [Tooltip("Мах масштаб")][SerializeField] private float _maxZoom = 4.7f;

    public float MoveSpeedCamera => _moveSpeedCamera;
    public float MoveEaseDurationCamera => _moveEaseDurationCamera;
    public float ZoomSpeed => _zoomSpeed;
    public float DurationZoom => _durationZoom;
    public float MinZoom => _minZoom;
    public float MaxZoom => _maxZoom;
    public Ease TypeEaseCamera => _typeEaseCamera;
}