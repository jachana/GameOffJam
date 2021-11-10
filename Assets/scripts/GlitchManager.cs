using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    // Start is called before the first frame update
    List<IGlitchable> glitch_list = new List<IGlitchable>();
    private static GlitchManager _instance;
    public static GlitchManager Instance { get { return _instance; } }
    float timer= 2;
    float normal_time = 2;
    float glitch_time = 2;
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
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("NOW: " + glitch_list.Count);
            foreach (IGlitchable glitch in glitch_list)
            {
                glitch.ToggleGlitch();
            }
            if (is_glitching)
            {
                timer = normal_time;
            }
            else
            {
                timer = glitch_time;

            }
            is_glitching = !is_glitching;
        }
    }
}
