using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchablePersistent : MonoBehaviour
{
    IGlitchable _glitchable_component;

    private void Awake()
    {
        SceneManager.sceneLoaded += AddThisToGlitchList;

        _glitchable_component = GetComponent<IGlitchable>();
    }

    void AddThisToGlitchList(Scene scene, LoadSceneMode mode)
    {
        GlitchManager.Instance.AddGlitchableToList(_glitchable_component);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AddThisToGlitchList;
        GlitchManager.Instance.RemoveGlitchableOfList(_glitchable_component);
    }
}
