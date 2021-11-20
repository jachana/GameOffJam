using System.Collections;
using UnityEngine;

// I will not add requiere for SpriteRenderer because we may not use it later
public class Door : MonoBehaviour, IActivate
{
    [SerializeField]
    private SpriteRenderer lower_door, top_door;
    [SerializeField]
    private Collider2D collider;
    private bool is_active;
    void Start()
    {

        is_active = false;
    }

    void Update()
    {

    }

    public void Activate()
    {
        StartCoroutine(OpenDoor());
        is_active = true;
    }

    public void Deactivate()
    {
        StartCoroutine(CloseDoor());
        is_active = false;
    }
    float steps = 30f;
    float legth_in_seconds = .3f;
    float movement_requiered = 2.5f;
    IEnumerator OpenDoor()
    {
        for (int i = 0; i < steps; i++)
        {
            lower_door.transform.position += Vector3.right* movement_requiered / steps;
            top_door.transform.position += Vector3.left* movement_requiered / steps;
            yield return new WaitForSeconds(legth_in_seconds / steps);
        }
        collider.enabled = false;

    }

    IEnumerator CloseDoor()
    {
        for (int i = 0; i < steps; i++)
        {
            lower_door.transform.position += Vector3.left* movement_requiered / steps;
            top_door.transform.position += Vector3.right* movement_requiered / steps;
            yield return new WaitForSeconds(legth_in_seconds / steps);
        }

        collider.enabled = true;

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
