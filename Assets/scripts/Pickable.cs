using UnityEngine;

public enum MyFakeItems
{
    FAKE_BLOOD,
    FAKE_HEAD,
    FAKE_LEGS,
    FAKE_BODY,
    FAKE_TAIL
}

[RequireComponent(typeof(Animation))]
public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField]
    MyFakeItems _item_id;
    bool _has_been_picked = false;
    SpriteRenderer _sprite_renderer;
    Collider2D _collider;

    public void ManualInteract(PlayerInteractions interactor)
    {
        
    }

    private void Pick()
    {
        if (!_has_been_picked)
        {
            PlayerInventory.Instance.FoundItem(_item_id);
            _has_been_picked = true;
            _sprite_renderer.color = new Color(0, 0, 0, .3f);
            //_collider.enabled = false;
        }
    }

    public void AutoInteract(PlayerInteractions interactor)
    {
        Pick();
    }
    void Start()
    {
        _sprite_renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    void Update()
    {

    }
}
