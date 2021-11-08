using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, IInteractable
{
    [SerializeField] public UnityEvent CallOnInteract;

    private IEnumerator ChangeVisualAspect()
    {
        GetComponent<SpriteRenderer>().color = Color.green;

        yield return new WaitForSeconds(1);

        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void ManualInteract()
    {
        CallOnInteract.Invoke();
        StartCoroutine(ChangeVisualAspect());
    }

    public void AutoInteract()
    {
        //highlight?
    }
}
