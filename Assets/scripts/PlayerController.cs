using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _player_speed = 2;
    [SerializeField]
    private float _jump_force = 45;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckPlayerInput();
    }

    void CheckPlayerInput()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _player_speed;

        bool is_grounded = Mathf.Abs(_rigidbody.velocity.y) < 0.0001;// looks ok but maybe its not the only way to check .. imagine you are on a slope .. then your velocity might not be 0 but you may still be grounded
        if (Input.GetButtonDown("Jump") && is_grounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jump_force), ForceMode2D.Impulse);
        }
    }
}
