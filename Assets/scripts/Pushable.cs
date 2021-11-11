using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour, IGlitchable
{
    [SerializeField] private float bounce_force = 1.3f;

    private bool is_glitching;
    private Rigidbody2D rigid_body;
    private SpriteRenderer sprite_renderer;

    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);

        rigid_body = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    public void ToggleGlitch()
    {
        is_glitching = !is_glitching;

        if(is_glitching)
        {
            rigid_body.bodyType = RigidbodyType2D.Static;
            sprite_renderer.color = Color.red;
        }
        else
        {
            rigid_body.bodyType = RigidbodyType2D.Dynamic;
            sprite_renderer.color = Color.green;
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
}
