using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public Camera camera;
    private int startTimer;
    private Vector3 moveVect;
    // Use this for initialization
    void Awake()
    {
        startTimer = 600;
        moveVect = new Vector3(-0.01f, -0.005f, 0.0016f);
    }

    //(-106, 18, 54.5) (-109, 16.5 , 55)
    // Update is called once per frame
    void Update () {
        if (startTimer > 0)
        {
            startTimer--;
        }
        else
        {
            if (transform.position.x < -106f)
            {
                transform.SetPositionAndRotation(transform.position - moveVect, transform.rotation);
            }
        }
	}
}
