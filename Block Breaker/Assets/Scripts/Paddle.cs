using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    float mousePosInUnits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //giving the position of the mouse and the screen width in pixels, by dividing, we know where we are in the screen (normalized, given in percentage).
        //Then by timing it by the width in Unity Units, now we know where our mouse is in the worldspace
        Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //by putting transform.position.y into the y-axis of the Vector 2, we're saying us the current objects y-location as the input for the y-component of the vector
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        //now change the position of the object to the new Vector2 coordinates that we're feeding into the transform menu
        transform.position = paddlePos;
    }
}
