using UnityEngine;

public class PlatformSpeedMove : Platform
{

    [SerializeField]
    Vector3 _movement_vector;

    Vector3 _initial_position;
    float _clock, _enhancment_multiplier = 1.2f;

    void Start()
    {
        _clock = _offset *= Mathf.PI;
        _initial_position = transform.position;
    }

    void Update()
    {
        if (_is_active)
        {
            _clock += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(transform.position, _initial_position + _movement_vector * Mathf.Sin(_clock ), .5f);
        }
    }

    public override void Enhance()
    {
        _speed *= _enhancment_multiplier;
    }

    public override void Diminish()
    {
        _speed /= _enhancment_multiplier;
    }
}
