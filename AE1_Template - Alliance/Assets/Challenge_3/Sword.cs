using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    GameObject Player;
    
    Transform EndPoint;

    Transform Direction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Square");

        EndPoint = transform.Find("Point");

    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawLine(transform.position, EndPoint.position, Color.red);
        if (Physics2D.Linecast(transform.position, EndPoint.position,  1 << LayerMask.NameToLayer("Player")))
        {

            Player.GetComponent<Player>().KillPlayer();
        }


    }
}
