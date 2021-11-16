using UnityEngine;

public class PlatformTargetMove : Platform
{
    [SerializeField]
    Transform _desired_position;
    Vector3 _starting_position, _target_position;

    public override void Diminish()
    {
    }

    public override void Enhance()
    {
    }

    void Start()
    {
        _starting_position = transform.position;
        _target_position = _starting_position;
    }

    void Update()
    {
        if (_is_active)
        {
            _target_position = _desired_position.position;
        }
        else
        {
            _target_position = _starting_position;
        }
        transform.position = Vector3.Lerp(transform.position, _target_position, Time.deltaTime * _speed);
    }
}
