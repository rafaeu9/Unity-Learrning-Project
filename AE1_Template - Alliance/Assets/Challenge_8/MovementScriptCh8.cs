using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptCh8 : MonoBehaviour
{
    public float MoveSpeed;

    Animator AnimationState;

    public float JumpForce = 3;

    Rigidbody2D MyRB2D;

    public bool IsCliming = false;

    private GameObject clouds;

    bool IsGrounded = false;

    private void Start()
    {
        AnimationState = GetComponent<Animator>();
        MyRB2D = GetComponent<Rigidbody2D>();
        clouds = transform.Find("Particle System").gameObject;
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << LayerMask.NameToLayer("Ground")))
            IsGrounded = true;        
        else
            IsGrounded = false;

        Jump();        

        MoveHorizontal();

        if (IsCliming)
            Climing();

        AnimationState.SetBool("IsGrounded", IsGrounded);
        AnimationState.SetFloat("fall", MyRB2D.velocity.y);


    }

    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (IsGrounded)
            {
                SFXManager.GlobalSFXManager.PlaySFX(SFXManager.ClipNames.Jump);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
                AnimationState.SetTrigger("Jump");
            }                     
        }
        
        

    }

    private void MoveHorizontal()
    {
        Vector3 theScale = transform.localScale;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));

            AnimationState.SetFloat("Running", MoveSpeed);

            if (theScale.x > 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(MoveSpeed * Time.deltaTime, 0));

            AnimationState.SetFloat("Running", MoveSpeed);

            if (theScale.x < 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }

        }
        else
        {
            AnimationState.SetFloat("Running", 0);
        }
    }

    private void Climing()
    {

        GetComponent<Animator>().SetFloat("Climb", 1);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up;
            GetComponent<Animator>().speed = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down;
            GetComponent<Animator>().speed = -1;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().speed = 0;
        }
    }

    public void SpawnCloud()
    {
        clouds.GetComponent<ParticleSystem>().Play();
    }

}
