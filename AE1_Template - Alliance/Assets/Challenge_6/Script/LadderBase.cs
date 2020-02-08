using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBase : MonoBehaviour
{
    GameObject Player;
    private bool OnLadder = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;

            Player.GetComponent<Animator>().SetFloat("Climb", 1);
            Player.GetComponent<MovementScriptCh6>().IsCliming = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.GetComponent<MovementScriptCh6>().IsCliming = false;
            Player.GetComponent<Animator>().SetFloat("Climb", 0);
            Player.GetComponent<Animator>().speed = 1;


            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    

}
