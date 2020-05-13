using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Need to use the namespace that will let us manage our scenes

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        //declared a integer that tracks where we currently on
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Bring up the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
