using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour, IGlitchable
{
    [SerializeField] AudioSource normal_music;
    [SerializeField] AudioSource glitchy_music;
    [SerializeField] float time_to_fade = 0.25f;
    [SerializeField] float max_volume = 0.25f;

    bool is_glitching = false;
    private static MusicPlayer Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        normal_music.volume = max_volume;
        glitchy_music.volume = 0;
    }

    public void ToggleGlitch(bool value)
    {
        is_glitching = value;
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
            float volume_fade_in = Mathf.Lerp(0, max_volume, time_elapsed / time_to_fade);
            track_fade_in.volume = volume_fade_in;
            track_fade_out.volume = max_volume - volume_fade_in;
            time_elapsed += Time.deltaTime;

            yield return null;
        }
    }

}
