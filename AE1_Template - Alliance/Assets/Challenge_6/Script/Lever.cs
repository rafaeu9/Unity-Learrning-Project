using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private GameObject Player;
    private GameObject LeverHandle;
    private GameObject Door;
    private GameObject DoorGreen;
    private bool PlayerIn;
    public bool State;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        LeverHandle = GameObject.Find("Lever_Handle");
        Door = GameObject.Find("Door");
        DoorGreen = GameObject.Find("DoorGreen");
        State = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIn)
        {
            if (Input.GetKeyDown(KeyCode.E) && !State)
            {
                Debug.Log("Open Door");
                State = true;
                LeverHandle.GetComponent<Animation>().Play();
                Door.GetComponent<Animation>().Play();
                DoorGreen.GetComponent<Animation>().Play();

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIn = false;
    }
}

