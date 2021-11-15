using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SeeSaw : MonoBehaviour, IGlitchable
{
    [SerializeField]
    protected Transform _pivot, _platform;
    bool _is_glitching = false;
    protected SpriteRenderer _sprite_renderer;
    protected Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
        _sprite_renderer = GetSpriteRenderer();
        _rigidbody = _platform.GetComponent<Rigidbody2D>();
    }

    protected abstract SpriteRenderer GetSpriteRenderer();
    protected abstract void StartGlitch();
    protected abstract void EndGlitch();

    public void ToggleGlitch()
    {
        _is_glitching = !_is_glitching;
        if (_is_glitching)
        {
            StartGlitch();
        }
        else
        {
            EndGlitch();
        }
    }
}
