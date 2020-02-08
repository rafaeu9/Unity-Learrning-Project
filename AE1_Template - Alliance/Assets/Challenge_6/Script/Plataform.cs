using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Plataform");
        if (collision.gameObject == Player)
        {
            Debug.Log("Plataform");
            Player.transform.parent = transform;
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(Player))
        {
            Player.transform.parent = null;
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
