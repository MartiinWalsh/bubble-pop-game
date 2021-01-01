using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBubbles; //Serialized for debugging purposes

    //cached ref
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBubbles++ ;
    }

    public void BubbleDestroyed()
    {
        breakableBubbles--;
        if(breakableBubbles <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }


}
