using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f); //create a new audio file that'll play the sound on collision, then audio file will disappear. 
                                                                      //where the audio file will play will be on the camera, as the distance to camera will determine how loud the sound will be, and how loud it'll be
        Destroy(gameObject);
    }
}
