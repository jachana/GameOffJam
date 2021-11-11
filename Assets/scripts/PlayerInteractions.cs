using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] List<Collider2D> _interactables_list;

    void Start()
    {
        _interactables_list = new List<Collider2D>();
    }

    void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        foreach (Collider2D interactableObject in _interactables_list)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
            {
                interactableObject.GetComponent<IInteractable>().ManualInteract(this);
            }
            interactableObject.GetComponent<IInteractable>().AutoInteract(this);

        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        AddColiderToList(otherCollider);
    }

    //called when something exits the trigger
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        RemoveColliderToList(otherCollider);
    }

    private void RemoveColliderToList(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<IInteractable>() != null &&
            _interactables_list.Contains(otherCollider))
        {
            _interactables_list.Remove(otherCollider);
        }
    }

    private void AddColiderToList(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<IInteractable>() != null &&
            !_interactables_list.Contains(otherCollider))
        {
            _interactables_list.Add(otherCollider);
        }
    }



}
