using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameter
    [SerializeField] Paddle paddle1; //telling the ball what Paddle object to look for
    [SerializeField] float x_Velocity = 2f;
    [SerializeField] float y_Velocity = 15f;

    //state
    Vector2 paddleToBallVector; //the distance between the paddle and ball (comparing their mid-point)
    bool ballHasBeenLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; //at the beginning of the game, it figures out what the distance between the ball and paddle is

    }

    // Update is called once per frame
    void Update()
    {
        //if ballHasBeenLaunched is still false, keep the ball onto the paddle, else if it's true, send the shit flying
        if (!ballHasBeenLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }        

    }

    private void LaunchOnMouseClick()
    {
        //when the user left clicks on the mouse, send a new velocity vector to the ball's rigidBody2D velocity, that will then launch it
        if (Input.GetMouseButtonDown(0))
        {
            ballHasBeenLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x_Velocity, y_Velocity);
        }
            

    }

    private void LockBallToPaddle()
    {
        //Have to figure out where the paddle is currently in the game
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        //now the new position of the ball will calculte where the paddle is plus the distance that is between the paddle and the ball, resulting in the ball following the paddle
        transform.position = paddlePos + paddleToBallVector;
    }
}
