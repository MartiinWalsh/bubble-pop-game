using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticles;
    [SerializeField] int maxHits;

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
        HandleHit();

    }

    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit == maxHits)
            {
                gameStatus.AddToScore();
                DestroyBubble();
            }

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
