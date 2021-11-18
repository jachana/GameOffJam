using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, IInteractable
{
    [SerializeField] public UnityEvent CallOnInteract;
    [SerializeField]
    public IActivate activatable;
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
