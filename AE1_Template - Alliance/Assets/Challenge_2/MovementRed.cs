using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRed : MonoBehaviour
{
    public float MoveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal Joystick") * MoveSpeed * Time.deltaTime,
                                Input.GetAxis("Vertical Joystick") * MoveSpeed * Time.deltaTime, 0));
    }
}
