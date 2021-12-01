using System.Collections.Generic;
using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    // Start is called before the first frame update
    List<IGlitchable> glitch_list = new List<IGlitchable>();
    private static GlitchManager _instance;
    public static GlitchManager Instance { get { return _instance; } }
    float timer = 5;
    float normal_time = 5;
    float glitch_time = 5;
    bool is_glitching = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddGlitchableToList(IGlitchable glitchable)
    {
        glitch_list.Add(glitchable);
    }

    public void RemoveGlitchableOfList(IGlitchable glitchable)
    {
        glitch_list.Remove(glitchable);
    }

    public bool IsGlitching()
    {
        return is_glitching;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            is_glitching = !is_glitching;

            foreach (IGlitchable glitch in glitch_list)
            {
                glitch.ToggleGlitch(is_glitching);
            }

            if (is_glitching)
            {
                timer = glitch_time;
            }
            else
            {
                timer =normal_time ;

            }
        }
    }

    public float GetTimerPortion()
    {
        float fraction_of_fill;
        if(is_glitching)
        {
            fraction_of_fill = timer / glitch_time - 1;
        }
        else
        {
            fraction_of_fill = 1 - (timer / normal_time);
        }

        return fraction_of_fill;
    }
}
