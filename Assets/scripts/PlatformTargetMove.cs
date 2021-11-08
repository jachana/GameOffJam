using UnityEngine;

public class PlatformTargetMove : Platform
{
    [SerializeField]
    Transform _desired_position;
    Vector3 _starting_position, _target_position;

    public override void Diminish()
    {
        _target_position = _starting_position;
    }

    public override void Enhance()
    {
        _target_position = _desired_position.position;
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
            transform.position = Vector3.Lerp(transform.position, _target_position, Time.deltaTime * _speed);
        }
    }
}
