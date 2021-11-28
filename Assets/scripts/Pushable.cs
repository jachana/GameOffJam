using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Spawnable, IGlitchable
{
    [SerializeField] private float bounce_force = 1.3f;

    private bool is_glitching;
    private Rigidbody2D rigid_body;
    private SpriteRenderer sprite_renderer;
    private Vector2 initial_position;
    [SerializeField] private Sprite normal_sprint,glitchy_sprite;

    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
        rigid_body = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        initial_position = transform.position;
    }

    public void ToggleGlitch(bool value)
    {
        is_glitching = value;
        if (is_glitching)
        {
            sprite_renderer.sprite = glitchy_sprite;
        }
        else
        {
            sprite_renderer.sprite = normal_sprint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(is_glitching)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Rigidbody2D player_rigid_body = collision.gameObject.GetComponent<Rigidbody2D>();
                float x_speed = player_rigid_body.velocity.x;
                float y_speed = collision.relativeVelocity.y * bounce_force * -1;
                Vector2 bounce_speed = new Vector2(x_speed, y_speed);
                player_rigid_body.velocity = bounce_speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Deadly"))
        {
            if (is_spawned)
                ResetSpawnable();
            else
                ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = initial_position;
        rigid_body.velocity = Vector3.zero;
    }
    private void OnDestroy()
    {
        GlitchManager.Instance.RemoveGlitchableOfList(this);
    }
}
