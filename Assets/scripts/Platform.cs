using System.Collections;
using UnityEngine;

public class Platform : PlatformBase
{
    [SerializeField]
    protected float _speed, _offset;

    public override void Diminish()
    {
    //    throw new System.NotImplementedException();
    }

    public override void Enhance()
    {
    //    throw new System.NotImplementedException();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.GetComponent<Platform>())
        {
            col.transform.parent = transform;
            if (col.gameObject.tag == "Pushable")
            {
                col.gameObject.AddComponent<Platform>();
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.transform.parent = null;
    }
}
