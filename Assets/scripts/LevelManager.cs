using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void ResetLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(current_scene.name);
    }

    public void NextLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        int next_scene_index = (current_scene.buildIndex + 1) % SceneManager.sceneCount;
        SceneManager.LoadScene(next_scene_index);
    }
}
