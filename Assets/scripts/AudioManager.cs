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
    private bool isMute = false;

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
        isMute = !isMute;
        if(isMute)
        {
            audioMuteButtonImage.sprite = audioInactive;
            AudioListener.volume = 0f;
        }
        else
        {
            audioMuteButtonImage.sprite = audioActive;
            AudioListener.volume = 1f;
        }

    }
}
