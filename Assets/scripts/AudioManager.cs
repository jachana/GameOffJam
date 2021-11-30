using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sprite audioActive;
    [SerializeField] Sprite audioInactive;
    [SerializeField] Image audioMuteButtonImage;
    private AudioManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }


    public void ToggleAudio()
    {
        AudioListener.pause = !AudioListener.pause;
        if(AudioListener.pause)
        {
            audioMuteButtonImage.sprite = audioInactive;
        }
        else
        {
            audioMuteButtonImage.sprite = audioActive;
        }

    }
}
