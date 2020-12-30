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

    // Update is called once per frame
    void Update()
    {
        // Current mouse position
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // Current fish sprite position
        Vector2 fishPos = new Vector2(transform.position.x, transform.position.y);
        // Set fish x positon to the mouse position (If within the screen size)
        fishPos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = fishPos;
        Debug.Log(mousePosInUnits);
    }
}
