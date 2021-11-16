using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour, IGlitchable
{
    [SerializeField] AudioSource normal_music;
    [SerializeField] AudioSource glitchy_music;
    [SerializeField] float time_to_fade = 0.25f;

    bool is_glitching = false;

    // Start is called before the first frame update
    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
        normal_music.volume = 1;
        glitchy_music.volume = 0;
    }

    public void ToggleGlitch()
    {
        is_glitching = !is_glitching;
        StartCoroutine(FadeBetweenTracks());
    }

    private IEnumerator FadeBetweenTracks()
    {
        float time_elapsed = 0;

        AudioSource track_fade_in, track_fade_out;
        if(is_glitching)
        {
            track_fade_in = glitchy_music;
            track_fade_out = normal_music;
        }
        else
        {
            track_fade_in = normal_music;
            track_fade_out = glitchy_music;
        }

        track_fade_in.timeSamples = track_fade_out.timeSamples;

        while (time_elapsed <= time_to_fade)
        {
            float volume_fade_in = Mathf.Lerp(0, 1, time_elapsed / time_to_fade);
            track_fade_in.volume = volume_fade_in;
            track_fade_out.volume = 1 - volume_fade_in;
            time_elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
