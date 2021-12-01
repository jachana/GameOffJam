using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarmed : MonoBehaviour
{
    [SerializeField] float timeSpeed = 0.5f;
    [SerializeField] float timeBeforeReset = 1f;
    Animator animator;

    string is_dead_key = "is_dead";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Deadly"))
        {
            animator.SetBool(is_dead_key, true);
            StartCoroutine(ResetLevelAfterTime());
        }
    }

    private IEnumerator ResetLevelAfterTime()
    {
        Time.timeScale = timeSpeed;

        yield return new WaitForSeconds(timeBeforeReset);

        Time.timeScale = 1f;

        LevelManager.Instance.ResetLevel();
    }
}
