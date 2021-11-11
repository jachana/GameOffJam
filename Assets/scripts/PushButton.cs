using System.Collections;
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

    public void ManualInteract(PlayerInteractions interactor)
    {
        CallOnInteract.Invoke();
        StartCoroutine(ChangeVisualAspect());
    }

    public void AutoInteract(PlayerInteractions interactor)
    {
        //highlight?
    }
}
