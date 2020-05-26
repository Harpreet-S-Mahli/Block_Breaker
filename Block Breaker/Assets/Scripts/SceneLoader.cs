using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Need to use the namespace that will let us manage our scenes

public class SceneLoader : MonoBehaviour
{
    // cache reference
    GameSession gameStatus;

    public void LoadNextScene()
    {
        //declared a integer that tracks where we currently on
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Bring up the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        gameStatus = FindObjectOfType<GameSession>();//to restart the script so the singleton patten within the script doesn't carry over when you restart the game
                                                    //Rather, it destroys and resets the GameSession script to start from scratch again
        gameStatus.Restart();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
