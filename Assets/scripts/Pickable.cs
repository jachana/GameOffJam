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

    public void ManualInteract(PlayerInteractions interactor)
    {
        if (!_has_been_picked)
        {
            PlayerInventory.Instance.FoundItem(_item_id);
            _has_been_picked = true;
            _sprite_renderer.color = new Color(0, 0, 0, .3f);
        }
    }

    public void AutoInteract(PlayerInteractions interactor)
    {
        Debug.Log("touched player");
    }
    void Start()
    {
        _sprite_renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

    }
}
