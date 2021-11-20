using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActivable : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D _collider;
    [SerializeField] public UnityEvent CallOnInteract;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<PlayerController>())
        {
            _collider.enabled = false;
            CallOnInteract.Invoke();
        }
    }
}
