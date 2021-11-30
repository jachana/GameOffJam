using UnityEngine;

public class PlatformDistanceMove : Platform
{

    [SerializeField]
    Vector3 _movement_vector;

    Vector3 _initial_position;
    float _clock, _enhancment_multiplier = 1.2f;
    [SerializeField]
    float wait_time = 0f;
    float current_wait_time;
    bool is_waiting = false;
    void Start()
    {
        _initial_position = transform.position;
    }

    void Update()
    {
        if (_is_active)
        {
            _clock += Time.deltaTime * _speed;
            float current_position = 1/2 + Mathf.Sin(_clock + _offset * Mathf.PI)/2;
            if (current_wait_time <= 0)
            {
                if (current_position >= 0)
                { 
                    transform.position = Vector3.Lerp(transform.position, _initial_position + _movement_vector * current_position, .5f); 
                }
                else
                {
                    current_wait_time = wait_time;
                    is_waiting = true;
                }
            }

            if (current_wait_time >= 0)
            {
                current_wait_time -= Time.deltaTime;
                if (current_wait_time <= 0)
                {
                    is_waiting = false;
                    _clock = _offset * Mathf.PI;
                }
            }


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
