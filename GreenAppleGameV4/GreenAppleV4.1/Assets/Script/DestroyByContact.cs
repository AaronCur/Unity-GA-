using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour {

    private int apple;
    public Text appleText;
    public string sceneNew;
    public AudioSource pickUpAudioSource;   //found at https://www.freesound.org/s/345299/
    public AudioSource levelCompleteAudioSource;     //found at https://www.freesound.org/s/274182/
    private int timer;
    private Rect rect;      //rectangle for the size of the screen
    public Texture2D image;     //the loading image for the next scene

    // Use this for initialization
    void Start () {
        apple = 0;
        SetCountText();
        timer = 1;            //larger number larger loadtime
        rect = new Rect(0, 0, Screen.width, Screen.height);     //sets the screen size to rect
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered: ");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("apple"))
        {
            other.gameObject.SetActive(false);
            apple = apple + 1;
            SetCountText();
            if (apple < 7)
            {
                pickUpAudioSource.Play();
            }

            if (apple >= 7)
            {
                levelCompleteAudioSource.Play();

                if (timer > 0)
                {
                    timer--;
                }
                if (timer == 0)
                { 
                    //loads end of game scene
                    SceneManager.LoadScene(1);   
                }
            }
        }
    }

    void SetCountText()
    {
        appleText.text = "Apples " + apple.ToString() + " / 7";
    }
    void OnGUI()
    {
        if (apple >= 7)
        {
            GUI.DrawTexture(rect, image, ScaleMode.ScaleToFit);      //if all the collectables are collected display the loading screen image
        }
    }
}
