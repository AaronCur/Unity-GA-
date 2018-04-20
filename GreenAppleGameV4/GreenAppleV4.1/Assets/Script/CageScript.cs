using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour {
    public float speed;


    private int hitCount = 0;


    private Rigidbody rb;

    private GameObject[] cages;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hitCount == 0)
        {
            if (other.gameObject.CompareTag("Hole"))
            {
                hitCount = 1;

                Vector3 liftMovement = new Vector3(0.0f, 1.0f, 0.0f);
                cages = GameObject.FindGameObjectsWithTag("Cage");
                foreach (GameObject c in cages)
                    c.transform.Translate(liftMovement * 3);

            }
        }
    }

}
