using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarmed : MonoBehaviour
{
    [SerializeField] LevelManager level_manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Deadly"))
        {
            Debug.Log("Player died");
            level_manager.ResetLevel();
        }
    }
}
