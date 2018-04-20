using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterMotor))]
//RequireComponent (CharacterMotor)
[AddComponentMenu("Character/FPS Input Controller")]
//@script AddComponentMenu ("Character/FPS Input Controller")


public class FPSInputController : MonoBehaviour
{
    public Camera gameCamera;
    public CharacterMotor motor;

    // Use this for initialization
    void Awake()
    {
        Cursor.visible = false;
        motor = GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardVector = new Vector3(0, 0, 0f);
        //Only move forward while the camera is facing between 15 degrees upwards and 45 degrees down
        if (gameCamera.transform.localEulerAngles.x > 345f || gameCamera.transform.localEulerAngles.x < 45f && 
            UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles.x < 45f || 
            UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles.x > 345f)
        {
            forwardVector = new Vector3(0, 0, 0.5f);
        }
        else
        {
            forwardVector = new Vector3(0, 0, 0f);
        }
        // Apply the direction to the CharacterMotor
        motor.inputMoveDirection = gameCamera.transform.rotation * forwardVector;
        //motor.inputJump = Input.GetButton("Jump");

        //Closes application if escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}