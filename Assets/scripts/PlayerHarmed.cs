using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarmed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Deadly"))
        {
            Debug.Log("Player died");
            LevelManager.Instance.ResetLevel();
        }
    }
}
