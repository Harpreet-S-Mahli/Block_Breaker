using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // configuration parameters
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f; //set a range on how high and low gamespeed can be, will become a slider in the inspector
    [SerializeField] int pointPerBlockDestroyed = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()//Implementing the singleton patten method on Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //This one finds HOW MANY of this object there are, different from the other as that one is finding a specific object
        if(gameStatusCount > 1)//if there is more than one, that indiciates that the current GameSession is not the FIRST one to be created
        {
            gameObject.SetActive(false);//Disables most of the script execution flow in Unity, cause Destroy(gameObject) is the last thing to be exectued in the flow
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);//if there isn't any other gameStauts, DON'T destroy when loading up
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed; //will alter how fast the game will run
    }

    //When a block is destroyed, update the total score

    public void AddToScore()
    {
        currentScore += pointPerBlockDestroyed;
        scoreText.text =  currentScore.ToString();
    }

    public void Restart() //Called from SceneLoader.cs to destroy the object so it doesn't carry the data over when the player restarts the game
    {
        Destroy(gameObject);
    }

    //If the player selects autoplay in the inspector, return the variable
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
