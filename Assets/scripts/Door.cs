using System.Collections;
using UnityEngine;

// I will not add requiere for SpriteRenderer because we may not use it later
[RequireComponent(typeof(Rigidbody2D))]
public class Door : MonoBehaviour, IActivate
{
    private Rigidbody2D _rigid_body;
    private SpriteRenderer _sprite;

    private bool is_active;
    [SerializeField] float active_time = 0f;

    void Start()
    {
        _rigid_body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        is_active = false;
    }

    void Update()
    {

    }

    public void Activate()
    {
        _rigid_body.simulated = false;
        _sprite.color = Color.cyan;
        is_active = true;
    }

    public void Deactivate()
    {
        _rigid_body.simulated = true;
        _sprite.color = Color.yellow;
        is_active = false;
    }

    public void Enhance()
    {
        throw new System.NotImplementedException();
    }

    public void Diminish()
    {
        throw new System.NotImplementedException();
    }

    public void Toggle()
    {
        if (is_active)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public void ActivateForSeconds(float time_t)
    {
        if (!is_active)
            StartCoroutine(TemporalActivation(time_t));
    }

    private IEnumerator TemporalActivation(float time_t)
    {
        Activate();

        yield return new WaitForSeconds(time_t);

        Deactivate();
    }

    public void ToggleGlitch()
    {
        throw new System.NotImplementedException();
    }
}
