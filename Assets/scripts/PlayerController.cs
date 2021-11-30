using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _player_speed = 2;
    [SerializeField]
    private float _jump_force = 45;

    private Rigidbody2D _rigidbody;
    private bool _is_grounded;
    private bool _is_pushing;
    private SpriteRenderer _sprite_renderer;
    private Animator _animator;
    private float horizontal_direction;

    // Animation keys
    string is_running_key = "is_running";
    string is_grounded_key = "is_grounded";
    string is_pushing_key = "is_pushing";
    string y_velocity_key = "y_velocity";

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite_renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _is_pushing = false;
    }

    void Update()
    {
        CheckPlayerInput();
        UpdateAnimatorKeys();
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(horizontal_direction * _player_speed, _rigidbody.velocity.y);
    }

    void CheckPlayerInput()
    {
        horizontal_direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _is_grounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jump_force), ForceMode2D.Impulse);
        }
    }

    void UpdateAnimatorKeys()
    {
        bool is_running = horizontal_direction != 0;
        _animator.SetBool(is_running_key, is_running);

        _animator.SetBool(is_grounded_key, _is_grounded);
        _animator.SetBool(is_pushing_key, _is_pushing);
        _animator.SetFloat(y_velocity_key, _rigidbody.velocity.y);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            Vector2 pushable_position = collision.gameObject.transform.position;
            Vector2 player_position = transform.position;
            Vector2 difference = (pushable_position - player_position).normalized;

            // check if the collision is vertical or horizontal
            if (difference.y == 0 || Mathf.Abs(difference.x / difference.y)  > 1)
            {
                _is_pushing = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            _is_pushing = false;
        }
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform")  || 
            otherCollider.gameObject.CompareTag("Pushable"))
        {
            _is_grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform") ||
            otherCollider.gameObject.CompareTag("Pushable"))
        {
            _is_grounded = false;
        }
    }
}
