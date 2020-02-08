using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptCh5 : MonoBehaviour
{
    public float MoveSpeed;


    private void Start()
    {

      
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, 0);
    }
}
