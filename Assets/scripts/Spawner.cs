using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnable_prefab;
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
            Transform go =Instantiate(spawnable_prefab, transform.position, Quaternion.identity);
            go.localScale = Vector3.one * scale;
        }
        has_spawned = true;

    }
}
