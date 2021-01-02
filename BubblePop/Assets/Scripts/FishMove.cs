using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    //Config parameters
    [SerializeField] float screenWidthInUnits = 16f;
    //Edges of screen for sprite
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 30f;

    // cache ref
    GameStatus gameStatus;
    Ball theBall;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Current fish sprite position
        Vector2 fishPos = new Vector2(transform.position.x, transform.position.y);
        // Set fish x positon to the mouse position (If within the screen size)
        fishPos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = fishPos;
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
