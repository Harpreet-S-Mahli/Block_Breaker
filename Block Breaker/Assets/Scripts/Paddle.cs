using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration components
    [SerializeField] float min_X = 1f;
    [SerializeField] float max_X = 2f;
    [SerializeField] float screenWidthInUnits = 16f;

    //cache references
    GameSession myGameSession;
    Ball myBall;

    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();

    }

    // Update is called once per frame
    void Update()
    {

        //by putting transform.position.y into the y-axis of the Vector 2, and vice versa for x, we're saying use the current objects y-location as the input for the y-component of the vector, and same for x
        Vector2 paddlePos = new Vector2(transform.position.y, transform.position.y);
        //confine the x position of the paddle(now following the mouse) in between the canvas so it doesn't go off screen
        paddlePos.x = Mathf.Clamp(GetXPos(), min_X, max_X);
        //now change the position of the object to the new Vector2 coordinates that we're feeding into the transform menu
        transform.position = paddlePos;
    }

    private float GetXPos() //if the autoplay in gamesession.cs is enabled true, then return the ball position so the paddle with automatically follow it without input, else it'll follow where the mouse is
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            //giving the position of the mouse and the screen width in pixels, by dividing, we know where we are in the screen (normalized, given in percentage).
            //Then by timing it by the width in Unity Units, now we know where our mouse is in the worldspace
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
