using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory _instance;

    Dictionary<MyFakeItems, bool> _requiered_item_list = new Dictionary<MyFakeItems, bool>()
    {
        { MyFakeItems.FAKE_BLOOD, false },
        { MyFakeItems.FAKE_HEAD,  false },
        { MyFakeItems.FAKE_BODY,  false },
        { MyFakeItems.FAKE_TAIL,  false },
        { MyFakeItems.FAKE_LEGS,  false }
    };

    public static PlayerInventory Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void FoundItem(MyFakeItems item_id)
    {
        _requiered_item_list[item_id]= true;
    }
}
