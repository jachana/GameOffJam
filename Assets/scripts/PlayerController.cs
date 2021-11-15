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

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckPlayerInput(); 
    }

    void CheckPlayerInput()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _player_speed;

        //bool is_grounded = Mathf.Abs(_rigidbody.velocity.y) < 0.0001;// looks ok but maybe its not the only way to check .. imagine you are on a slope .. then your velocity might not be 0 but you may still be grounded
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
