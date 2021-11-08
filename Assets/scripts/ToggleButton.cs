using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour, IInteractable
{

    bool _is_active = false;

    [SerializeField] public UnityEvent CallOnInteract;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Activate()
    {
        CallOnInteract.Invoke();
        GetComponent<SpriteRenderer>().color = Color.green;
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 135f);
    }

    private void Deactivate()
    {
        CallOnInteract.Invoke();
        GetComponent<SpriteRenderer>().color = Color.red;
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 45f);
    }

    public void ManualInteract()
    {
        if (!_is_active)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
        _is_active = !_is_active;
    }

    public void AutoInteract()
    {
        //highlight?
    }
}
