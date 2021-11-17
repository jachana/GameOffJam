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
    private Animator _animator;
    private float horizontal_direction;

    // Animation keys
    string is_running_key = "is_running";

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite_renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckPlayerInput();
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(horizontal_direction * _player_speed, _rigidbody.velocity.y);
    }

    void CheckPlayerInput()
    {
        horizontal_direction = Input.GetAxisRaw("Horizontal");

        bool is_running = horizontal_direction != 0;
        _animator.SetBool(is_running_key, is_running);

        if (Input.GetButtonDown("Jump") && _is_grounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jump_force), ForceMode2D.Impulse);
        }
    }

    void FlipCharacter()
    {
        if(horizontal_direction < 0)
        {
            _sprite_renderer.flipX = true;
        }
        else if(horizontal_direction > 0)
        {
            _sprite_renderer.flipX = false;
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
