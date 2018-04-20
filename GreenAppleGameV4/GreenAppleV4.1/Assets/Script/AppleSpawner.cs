using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour {
    public Transform[] apples;
    private Vector3[] spawns;
    private Vector3 spawn1;
    private Vector3 spawn2;
    private Vector3 spawn3;
    private bool easymMode;
    private int spawnAmount;
    private bool started;
    private int index;
    // Use this for initialization
    void Start () {
        index = 0;
        started = false;
        spawnAmount = 13;
        easymMode = true;
        spawn1 = new Vector3(-34.37f, 0.11f, -30.21f);
        spawn2 = new Vector3(-28.25f, 0.11f, -28.58f);
        spawn3 = new Vector3(-31.2f, 0.11f, -22.53f);
        spawns = new Vector3[13];
        spawns[0] = new Vector3(39.07f, -0.21f, 27.84f);
        spawns[1] = new Vector3(9.5f, 0.3f, 30.28f);
        spawns[2] = new Vector3(-23.7f, 0.0f, 31.96f);
        spawns[3] = new Vector3(4.5f, 1.85f, 97.39f);
        spawns[4] = new Vector3(-65.5f, 0.22f, 48.66f);
        spawns[5] = new Vector3(-65.44f, 0.14f, 16.8f);
        spawns[6] = new Vector3(-81.65f, -0.07f, 2.14f);
        spawns[7] = new Vector3(-61.9f, 0.06f, -67.5f);
        spawns[8] = new Vector3(4.2f, 0.06f, -67.5f);
        spawns[9] = new Vector3(-86.2f, 0.14f, 1.6f);
        spawns[10] = new Vector3(-89.75f, 0.22f, 55.16f);
        spawns[11] = new Vector3(50.9f, -0.1f, -31.3f);
        spawns[12] = new Vector3(72.8f, 2.77f, 75.7f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (easymMode == true)
            {
                //variables holds the spawn amount +1 for the random number generator to work
                apples[0].transform.SetPositionAndRotation(spawn1, apples[0].transform.rotation);
                apples[1].transform.SetPositionAndRotation(spawn2, apples[1].transform.rotation);
                apples[2].transform.SetPositionAndRotation(spawn3, apples[2].transform.rotation);
                index = 3;
            }
            for (; index < apples.Length; index++)
            {
                int pos = Random.Range(0, spawnAmount);
                spawnAmount--;
                apples[index].transform.SetPositionAndRotation(spawns[pos], apples[index].transform.rotation);
                spawns[pos] = spawns[spawns.Length - 1];
            }
            started = true;
        }
    }
}