using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlitchBar : MonoBehaviour
{
    [SerializeField] Sprite normal_bar;
    [SerializeField] Sprite glitchy_bar;
    [SerializeField] Image filling_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fill_portion = GlitchManager.Instance.GetTimerPortion();
        //Debug.Log(fill_portion);
        if(fill_portion > 0)
        {
            filling_image.sprite = normal_bar;
            filling_image.fillAmount = fill_portion;
        }
        else
        {
            filling_image.sprite = glitchy_bar;
            filling_image.fillAmount = 1 + fill_portion;
        }
    }
}
