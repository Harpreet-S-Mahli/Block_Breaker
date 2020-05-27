using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration paramters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gameStatus;

    // state variables
    [SerializeField] int timesHit;  //TODO only serialized for debug purposes

    private void Start()
    {
        level = FindObjectOfType<Level>();//Looking for a particular thing called level, like SerializeFiled, can call methods from that game-object reference into another script 
        gameStatus = FindObjectOfType<GameSession>();
        if(tag== "Breakable")
        {
            level.CountBreakableBlocks(); //at the start of when a instance of a block is created, it'll call the Level method that's reference and run it

        }
        //level.CountBreakableBlocks(); //at the start of when a instance of a block is created, it'll call the Level method that's reference and run it
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            timesHit++;
            if(timesHit >= maxHits)//if the right number of times to hit a block is reached, then destroy the block
            {
                TriggerSparklesVFX();
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()//whenever the block gets hit, the next sprite to appear will be displayed based on the how many hits that blocvk can take
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f); //create a new audio file that'll play the sound on collision, then audio file will disappear. 
                                                                                       //where the audio file will play will be on the camera, as the distance to camera will determine how loud the sound will be, and how loud it'll be

        gameStatus.AddToScore();
        level.BlockisGone();//decrease the count in Level script
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);//creates a instance of the particle prefab when the fucntion is called, based on the position and rotation of Block
        Destroy(sparkles, 1f);//get rid of the instance in the game hierachy when it's not needed after one seconds

    }
}
