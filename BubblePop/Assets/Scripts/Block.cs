using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticles;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameStatus gameStatus;

    // State

    [SerializeField] int timesHit; // TODO: Only serialising for debugging

    private void Start()
    {
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameStatus>();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {

            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {

        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit == maxHits)
        {
            gameStatus.AddToScore();
            DestroyBubble();
        }
        else
        {
            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Bubble sprite missing from array!" + gameObject.name);
        }
    }

    private void DestroyBubble()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BubbleDestroyed();
        TriggerBlockParticles();
    }

    private void TriggerBlockParticles()
    {
        GameObject blockParticleObject = Instantiate(blockParticles, transform.position, transform.rotation);
        Destroy(blockParticleObject, 1f);
    }
}
