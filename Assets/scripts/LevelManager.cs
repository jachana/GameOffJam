using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

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

    public void ResetLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(current_scene.name);
    }

    public void NextLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        Debug.Log(current_scene.name);
        int next_scene_index = (current_scene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        Debug.Log(current_scene.buildIndex + " " + 1 + "%" + SceneManager.sceneCountInBuildSettings);
        Debug.Log(next_scene_index);
        SceneManager.LoadScene(next_scene_index);
    }
}
