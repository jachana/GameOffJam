using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSeeSaw : MonoBehaviour, IGlitchable
{

    [SerializeField]
    Transform pivot, platform;
    [SerializeField]
    bool is_glitching = false;
    SpriteRenderer sprite;
    Rigidbody2D rigidbody;
    public void ToggleGlitch()
    {
        is_glitching = !is_glitching;
   

        if (is_glitching)
        {
            sprite.color = Color.red;
            rigidbody.freezeRotation = true;
        }
        else
        {
            sprite.color = Color.white;
            rigidbody.freezeRotation = false;

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
        sprite = platform.GetComponent<SpriteRenderer>();
        rigidbody = platform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
