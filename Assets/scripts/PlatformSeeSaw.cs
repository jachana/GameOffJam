using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSeeSaw : SeeSaw
{
    protected override void StartGlitch()
    {
        _sprite_renderer.color = Color.red;
        _rigidbody.freezeRotation = true;
    }

    protected override void EndGlitch()
    {
        _sprite_renderer.color = Color.white;
        _rigidbody.freezeRotation = false;
    }

    protected override SpriteRenderer GetSpriteRenderer()
    {
       return _platform.GetComponent<SpriteRenderer>();
    }
}
