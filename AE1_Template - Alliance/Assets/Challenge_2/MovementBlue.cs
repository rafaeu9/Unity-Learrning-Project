using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementBlue : MonoBehaviour
{
    public float MoveSpeed = 2;
    public GameObject enemy;

    private BoxCollider2D collider;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("left"))
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetButton("right"))
        {
            transform.Translate(new Vector2(MoveSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, -MoveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, MoveSpeed * Time.deltaTime));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            collider.enabled = !collider.enabled;
        }

        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime,
        //                                Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == enemy)
        {
            SceneManager.LoadScene("Challenge_3");
        }
    }
}