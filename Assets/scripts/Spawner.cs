using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Spawnable spawnable_prefab;
    [SerializeField]
    bool limited;
    bool has_spawned = false;
    [SerializeField]
    float scale =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
        if (!limited ||!has_spawned)
        {
            Spawnable go =Instantiate(spawnable_prefab, transform.position, Quaternion.identity);
            go.transform.localScale = Vector3.one * scale;
            go.setSpawnState(true);
        }
        has_spawned = true;

    }
}
