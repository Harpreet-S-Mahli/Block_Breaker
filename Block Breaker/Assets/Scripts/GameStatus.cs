using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // configuration parameters
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f; //set a range on how high and low gamespeed can be, will become a slider in the inspector
    [SerializeField] int pointPerBlockDestroyed = 5;

    // state variables
    [SerializeField] int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed; //will alter how fast the game will run
    }

    public void AddToScore()
    {
        currentScore += pointPerBlockDestroyed; 
    }
}
