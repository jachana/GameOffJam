using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NarrationClip
{
   C0_Introduction=0,
   C1_FirstJump=1
}
public class Narrator : MonoBehaviour
{
    [SerializeField]
    AudioSource _audio_source;
    [SerializeField]
    AudioClip[] _narration_clips;
    
    private static Narrator _instance;
    public static Narrator Instance { get { return _instance; } }

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
    public void NarrateClip(NarrationClip clip)
    {
        if (_narration_clips.Length > (int)clip)
        {
            _audio_source.clip = _narration_clips[(int)clip];
            _audio_source.Play();
        }
    }

}
