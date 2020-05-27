using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameter
    [SerializeField] Paddle paddle1; //telling the ball what Paddle object to look for
    [SerializeField] float x_Velocity = 2f;//Where and how fast the ball will launch along the x-axis
    [SerializeField] float y_Velocity = 15f;//Where and how fast the ball will launch along the y-axis
    [SerializeField] AudioClip[] ballSounds; //An array containing all sounds the ball makes on compact
    [SerializeField] float randomFactor = 0.2f; //To help break out a loop incase the ball only bounces side to side or up and down with no way of getting out

    //state
    Vector2 paddleToBallVector; //the distance between the paddle and ball (comparing their mid-point)
    bool ballHasBeenLaunched = false;

    //Cached Component References
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; //at the beginning of the game, it figures out what the distance between the ball and paddle is
        myAudioSource = GetComponent<AudioSource>();//Grab the audio component from the ball at the start of the game
        myRigidBody2D = GetComponent<Rigidbody2D>();//Grab the RigidBody2D compnent from the ball at the start of the game
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
            myRigidBody2D .velocity = new Vector2(x_Velocity, y_Velocity);
        }
            

    }

    private void LockBallToPaddle()
    {
        //Have to figure out where the paddle is currently in the game
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        //now the new position of the ball will calculte where the paddle is plus the distance that is between the paddle and the ball, resulting in the ball following the paddle
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Introduce a slight randomness so that the ball when it collides with something so that way, it won't get stuck in a endless loop
        Vector2 velocityRandomness = new Vector2 (UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));

        //Whenever collision happens, play that audio source all the way without getting interrupted by another collision only when game has been started
        if (ballHasBeenLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];//Have to add UnityEngine, cause it doesn't know if to use Unity random or System random
            myAudioSource.PlayOneShot(clip);
        }
        myRigidBody2D.velocity += velocityRandomness;
    }
}
