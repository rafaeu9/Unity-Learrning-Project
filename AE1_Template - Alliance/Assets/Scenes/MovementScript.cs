using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float MoveSpeed;



    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(MoveSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, -MoveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, MoveSpeed * Time.deltaTime));
        }
    }

}
