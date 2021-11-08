using UnityEngine;

public class PlatformDistanceMove : Platform
{

    [SerializeField]
    Vector3 _movement_vector;

    Vector3 _initial_position;
    float _clock, _enhancment_multiplier = 1.2f;

    void Start()
    {
        _initial_position = transform.position;
    }

    void Update()
    {
        if (_is_active)
        {
            _clock += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(transform.position, _initial_position + _movement_vector * Mathf.Sin(_clock), .5f);
        }
    }

    public override void Diminish()
    {
        _movement_vector /= _enhancment_multiplier;
    }

    public override void Enhance()
    {
        _movement_vector *= _enhancment_multiplier;
    }
}
