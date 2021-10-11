using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public static ControllerInput Instance { set; get; }
    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    public Vector2 swipeDelta, startTouch;

    private const float pixelLenght = 20;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            } 
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }

        swipeDelta = Vector2.zero;

        if (startTouch != Vector2.zero)
        {
            if(Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        if (swipeDelta.magnitude > pixelLenght)
        {
            float moveX = swipeDelta.x;
            float moveY = swipeDelta.y;

            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                if (moveX > 0)
                {
                    swipeRight = true;
                }
                else
                {
                    swipeLeft = true;
                }
            }
            else
            {
                if (moveY > 0)
                {
                    swipeUp = true;
                }
                else
                {
                    swipeDown = true;
                }
            }
            Debug.Log("swipeUp: " + swipeUp + "swipeDown: " + swipeDown + "swipeLeft: " + swipeLeft + "swipeRight: " + swipeRight);
            swipeDelta = startTouch = Vector2.zero;
        }
    }
}
