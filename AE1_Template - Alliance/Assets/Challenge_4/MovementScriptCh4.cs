using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptCh4 : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    Rigidbody2D Myrigid;
    Transform arrow;

    RaycastHit2D target;

    void Start()
    {
        Myrigid = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {

        
        Myrigid.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, Myrigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool IsGrounded=false;
            if(Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 1 << LayerMask.NameToLayer("Ground")))
            {
                IsGrounded = true;
            }
            
            if (IsGrounded)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));             
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            arrow = transform.Find("SteelArrow");
            if (arrow)
            {

                target = Physics2D.Raycast(transform.position, Vector2.right,10, 1 << LayerMask.NameToLayer("Ground"));
                Debug.DrawLine(transform.position, target.point, Color.red);
                arrow.transform.parent = null;
                //arrow.transform.Translate(target.point);

                arrow.GetComponent<Transform>().position = target.point;
                               
                arrow.gameObject.SetActive(true);

                arrow.GetComponent<CapsuleCollider2D>().isTrigger = false;

            }
        }

    }
}
