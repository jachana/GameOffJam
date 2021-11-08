using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class PlatformBase : MonoBehaviour, IActivate
{
    [SerializeField]
    protected bool _is_active;

    public virtual void Activate()
    {
        _is_active = true;
    }

    public virtual void ActivateForSeconds(float time_t)
    {
        StartCoroutine(TemporalToggle(time_t));
    }
    public virtual IEnumerator TemporalToggle(float time_t)
    {
        Enhance();
        yield return new WaitForSecondsRealtime(time_t);
        Diminish();
    }

    public virtual void Deactivate()
    {
        _is_active = false;
    }

    public abstract void Diminish();
    public abstract void Enhance();

    public virtual void Toggle()
    {
        _is_active = !_is_active;
    }
}
