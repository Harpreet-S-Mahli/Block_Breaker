﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();//Looking for a particular thing called level, like SerializeFiled, can call methods from that game-object reference into another script 
        level.CountBreakableBlocks(); //at the start of when a instance of a block is created, it'll call the Level method that's reference and run it
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f); //create a new audio file that'll play the sound on collision, then audio file will disappear. 
                                                                                       //where the audio file will play will be on the camera, as the distance to camera will determine how loud the sound will be, and how loud it'll be

        level.BlockisGone();//decrease the count in Level script
        Destroy(gameObject);
    }
}
