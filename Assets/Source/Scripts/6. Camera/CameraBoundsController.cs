using UnityEngine;

public class CameraBoundsController
{
    private Bounds _boundsLocation;
    private Vector2 _locationBoundsMin;
    private Vector2 _locationBoundsMax;

    public Vector2 LocationBoundsMin => _locationBoundsMin;
    public Vector2 LocationBoundsMax => _locationBoundsMax;

    public void SetBoundsLocation(SpriteRenderer locationSprite)
    {
        _boundsLocation = locationSprite.bounds;
        _locationBoundsMin = new Vector2(_boundsLocation.min.x, _boundsLocation.min.y);
        _locationBoundsMax = new Vector2(_boundsLocation.max.x, _boundsLocation.max.y);
    }
}