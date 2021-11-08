using System.Collections;
using System.Collections.Generic;
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

    public void ManualInteract()
    {
        PlayerInventory.Instance.FoundItem(_item_id);
    }

    public void AutoInteract()
    {
        Debug.Log("touched player");
        //info bubble?
    }
}
