using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour, IGlitchable
{
    [SerializeField] AudioSource normal_music;
    [SerializeField] AudioSource glitchy_music;

    bool is_glitching = false;

    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
    }

    public void ToggleGlitch()
    {
        is_glitching = !is_glitching;

        if (is_glitching)
            glitchy_music.timeSamples = normal_music.timeSamples;
        else
            normal_music.timeSamples = glitchy_music.timeSamples;

        normal_music.mute = is_glitching;
        glitchy_music.mute = !is_glitching;

    }
}
