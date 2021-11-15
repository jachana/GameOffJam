using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    NarrationClip clip;

    SpriteRenderer _sprite_renderer;
    Collider2D _collider;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<PlayerController>())
        {
            _collider.enabled = false;
            _sprite_renderer.enabled=false;
            Narrator.Instance.NarrateClip(clip);
        }
    }
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sprite_renderer = GetComponent<SpriteRenderer>();
    }
}
