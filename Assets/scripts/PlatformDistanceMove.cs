using UnityEngine;

public class PlatformDistanceMove : Platform
{

    [SerializeField]
    Vector3 _movement_vector;

    Vector3 _initial_position;
    Vector3 target_position;
    Vector3 temp_target_position, temp_base_position;
    float _clock, _enhancment_multiplier = 1.2f;
    [SerializeField]
    float wait_time = 0f;
    float current_wait_time;
    float limit;
    float max_movement;
    // Modify this value to make them all go faster
    float _speed_adjustment = 0.018f;
    bool is_waiting = false;
    bool is_going = true;
    void Start()
    {
        _initial_position = transform.position;
        target_position = _initial_position + _movement_vector;
        temp_target_position = target_position;
        temp_base_position = _initial_position;

        limit = _speed * _movement_vector.magnitude * 0.1f;
    }

    void Update()
    {
        if (_is_active)
        {
            if (is_waiting)
            {
                current_wait_time -= Time.deltaTime;
                if (current_wait_time <= 0)
                {
                    is_waiting = false;
                }
            }
            else
            {
                Vector3 delta = ( temp_target_position- temp_base_position);
                max_movement = delta.magnitude * _speed * _speed_adjustment;

                //Debug.Log();

                float distance = (transform.position - temp_target_position).magnitude;
                if (distance <= 0.1f)
                {
                    Debug.Log("ENTREEEEEEEE : " + distance);
                    if (wait_time > 0)
                    {
                        current_wait_time = wait_time;
                        is_waiting = true;
                    }
                    is_going = !is_going;
                    if (is_going)
                    {
                        temp_target_position = target_position;
                        temp_base_position = _initial_position;
                    }
                    else
                    {
                        temp_target_position = _initial_position;
                        temp_base_position = target_position;
                    }
                }
            }
            //_clock += Time.deltaTime * _speed;
            //float current_position = 1/2 + Mathf.Sin(_clock + _offset * Mathf.PI)/2;
            //if (current_wait_time <= 0)
            //{
            //    if (current_position >= 0)
            //    { 
            //        transform.position = Vector3.Lerp(transform.position, _initial_position + _movement_vector * current_position, .5f); 
            //    }
            //    else
            //    {
            //        current_wait_time = wait_time;
            //        is_waiting = true;
            //    }
            //}

            //if (current_wait_time >= 0)
            //{
            //    current_wait_time -= Time.deltaTime;
            //    if (current_wait_time <= 0)
            //    {
            //        is_waiting = false;
            //        _clock = _offset * Mathf.PI;
            //    }
            //}


        }
    }

    private void FixedUpdate()
    {
        if(_is_active && !is_waiting)
            transform.position = Vector3.MoveTowards(transform.position, temp_target_position, max_movement);
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
