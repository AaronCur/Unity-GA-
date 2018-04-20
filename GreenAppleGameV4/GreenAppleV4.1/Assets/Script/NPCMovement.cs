using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed;
    private Vector3 startPos;
    private Vector3 endPos;
    private int dir, prevDir;
    private int count;
    private int moveType;
    void Start()
    {
        moveType = 2;
        prevDir = 0;
        count = 0;
        dir = 1;
        speed = 10;     //sets the speed if the speed is set in the editor this can be removed
        startPos = transform.position;      //sets the start point as the position the object will return to to rotate back
        endPos = transform.position + new Vector3(30,0,0);      //sets the position allong the x axis from the start point the object will go to before turning around

    }

    // Update is called once per frame
    void Update () {
        if (moveType == 1)
        {
            if ((transform.position.x < endPos.x && dir == 1) || (transform.position.x > startPos.x && dir == 2))
            {               //moves the object in the direction its facing on the x axis (the blue axis)
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            else
            {
                if (count == 0)
                {           //only does it once
                    prevDir = dir;
                    dir = 0;
                }
                count++;
                if (count <= 90)            //needed for a full 180 degrees rotation
                {                           

                    transform.Rotate(Vector3.up * 2);       //right
                    // transform.Rotate(Vector3.down * 2);      //left
                    //the higher the * number the faster the object will rotate. if it is changed from 2 the count cap (90) will need to be adjusted too
                }
                else
                {                       //sets the direction when the rotation is finished
                    count = 0;
                    if (prevDir == 1)
                    {
                        dir = 2;
                    }
                    else
                    {
                        dir = 1;
                    }
                    prevDir = 0;
                }
            }
        }
        if (moveType == 2)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
            transform.Rotate(Vector3.up * 0.75f);           //the lower the * number the larger the circle motion will be  //higher = smaller
        }
    }
}
