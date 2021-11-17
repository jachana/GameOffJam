using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _player_speed = 2;
    [SerializeField]
    private float _jump_force = 45;

    private Rigidbody2D _rigidbody;
    private bool _is_grounded;
    private SpriteRenderer _sprite_renderer;
    private float movement_x_direction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckPlayerInput(); 
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(movement_x_direction * _player_speed, _rigidbody.velocity.y);
    }

    void CheckPlayerInput()
    {
        movement_x_direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _is_grounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jump_force), ForceMode2D.Impulse);
        }
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Platform>())
        {
            _is_grounded = true;
            _sprite_renderer.color = Color.green;
        }
    }
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Platform>())
        {
            _is_grounded = false;
            _sprite_renderer.color = Color.white;
        }
    }
}
