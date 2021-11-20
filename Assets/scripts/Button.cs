using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum ButtonType
{
    TOGGLE,
    PULSE,
    PERMANENT
}
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] public UnityEvent CallOnInteract;
    [SerializeField] Sprite off_sprite, on_sprite;
    SpriteRenderer sprite_renderer;
    [SerializeField]
    ButtonType button_type;
    bool has_been_activated=false, is_activated = false;
    private IEnumerator PulseInteraction()
    {
        TurnOn();
        yield return new WaitForSeconds(1);
        TurnOff();
    }

    public void ManualInteract(PlayerInteractions interactor)
    {
        switch (button_type)
        {
            case ButtonType.TOGGLE:
                Toggle();
                break;
            case ButtonType.PULSE:
                Pulse();
                break;
            case ButtonType.PERMANENT:
                Permanent();
                break;
            default:
                break;
        }
    }

    public void AutoInteract(PlayerInteractions interactor)
    {
        //highlight?
    }
    private  void TurnOn()
    {
        sprite_renderer.sprite = on_sprite;
        CallOnInteract.Invoke();
    }

    private void TurnOff()
    {
        sprite_renderer.sprite = off_sprite;
        CallOnInteract.Invoke();
    }

    public void Pulse()
    {
        StartCoroutine(PulseInteraction());
    }

    public void Toggle()
    {
        if (is_activated)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
        is_activated = !is_activated;
    }

    public void Permanent()
    {
        if(!has_been_activated)
            TurnOn();
        has_been_activated = true;
    }
    private void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
    }
}
