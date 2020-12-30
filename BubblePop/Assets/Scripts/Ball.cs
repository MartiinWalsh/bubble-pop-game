using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] FishMove fish1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;


    //State
    Vector2 fishToBallVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        fishToBallVector = transform.position - fish1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPanel();
            LaunchBallOnMouseClick();
        }
        
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPanel()
    {
        Vector2 fishPos = new Vector2(fish1.transform.position.x, fish1.transform.position.y);
        transform.position = fishPos + fishToBallVector;
    }
}
