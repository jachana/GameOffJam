using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IActivate
{

    [SerializeField]
    SpriteRenderer laser;
    [SerializeField]
    Collider2D collider;
    [SerializeField]
    bool is_active=true;



    public void Activate()
    {
        TurnOn();
    }

    public void ActivateForSeconds(float time_t)
    {
        StartCoroutine(TurnOffForSecsCorroutine((int)time_t));
    }

    public void Deactivate()
    {
        TurnOff();
    }

    public void Diminish()
    {
        throw new System.NotImplementedException();
    }

    public void Enhance()
    {
        throw new System.NotImplementedException();
    }

    public void Toggle()
    {
        is_active = !is_active;
        if (is_active)
            TurnOn();
        else
            TurnOff();
    }

    void TurnOn()
    {
        StartCoroutine(TurnOnCorroutine());
    }

    IEnumerator TurnOnCorroutine()
    {
        collider.enabled = true;
        is_active = true;
        laser.enabled = true;
        laser.color = Color.white;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(Random.value*0.1f);
            laser.enabled = false;
            yield return new WaitForSeconds(Random.value * 0.1f);
            laser.enabled = true;
        }
        laser.color = Color.white;

    }
    void TurnOff()
    {
        StartCoroutine(TurnOffCorroutine());
    }

    IEnumerator TurnOffForSecsCorroutine(int secs)
    {
        TurnOff();
        yield return new WaitForSeconds(secs);
        TurnOn();
    }
    IEnumerator TurnOffCorroutine()
    {
        collider.enabled = false;
        is_active = false;
        //laser.enabled = false;
        int total_steps = 100; 
        for (int i = 1; i <= total_steps; i++)
        {
            float value = (float)(total_steps - i) / total_steps;
            Color color = new Color(1, 1, 1, value);
            laser.color = color;
            yield return new WaitForSeconds(8/ total_steps);
        }
      

    }
    // Start is called before the first frame update
    void Start()
    {
        if (is_active)
            TurnOn();
        else
            TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
