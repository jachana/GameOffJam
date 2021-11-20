using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    Sprite background_texture;
    [SerializeField]
    int size;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject go = new GameObject();
                SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = background_texture;
                float texture_size_x = background_texture.bounds.size.x;
                float texture_size_y = background_texture.bounds.size.y;
                int x_offset = (i - size / 2);
                int y_offset = (j - size / 2);

                Vector3 offset= new Vector3(x_offset* texture_size_x, y_offset* texture_size_y, 50);
                go.transform.position += offset;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
