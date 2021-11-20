using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawnable : MonoBehaviour
{
    protected bool is_spawned;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  setSpawnState(bool value)
    {
        is_spawned = value;
    }

    public void ResetSpawnable()
    {
        spawner.has_spawned = false;
        Destroy(this);
    }

}
