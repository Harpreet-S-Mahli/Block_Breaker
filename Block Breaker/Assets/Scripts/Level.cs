using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    /*
    [SerializeField] Block[] totalBlocks;

    int beginningBlockCount;
    int blockCount;



    private void AddingBlocks()
    {
        blockCount = 0;

        for(int i = 0; i<totalBlocks.Length;++i)
        {
            ++blockCount;
        }
    }

    */
    // parameters
    [SerializeField] int breakableBlocks; //Searlized for debugging purposes

    // cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();//Finds a object of type SceneLoader, and now allows us to access it's methods within another game obejct. Another way like SeriealizeField
    }

    //Increase the count for every block in the level
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    //Decrease the count of the total block count for every block destroyed, if the number reaches zero, go to the next level
    public void BlockisGone()
    {
        breakableBlocks--;
        if(breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
