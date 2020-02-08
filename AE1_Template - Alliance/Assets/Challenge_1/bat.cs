using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{

    Rigidbody2D MyRigid;
    private GameObject player;

    public float TurnInterval;
    private float CurTurnInterval;
    SpriteRenderer My2DRenderer;
    public float BatSpeed;
    bool Movement = true;

    Vector2 currentVelocity;


    private void Awake()
    {
        player = GameObject.Find("Explorer_Orc");

    }

    // Start is called before the first frame update
    void Start()
    {
        MyRigid = GetComponent<Rigidbody2D>();
        My2DRenderer = GetComponent<SpriteRenderer>();
        MyRigid.velocity = new Vector2(-BatSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if ((transform.parent == null))
            {
                transform.parent = player.transform;

                transform.localPosition = new Vector2(0, transform.localPosition.y);


                currentVelocity = MyRigid.velocity;

                MyRigid.velocity = new Vector2(0, 0);                

               
                
                Movement = false;
            }
            else
            {
                transform.parent = null;                

                Movement = true;

                MyRigid.velocity = currentVelocity;
            }
        }

        if (Movement)
        {
            CurTurnInterval += Time.deltaTime;
            if (CurTurnInterval > TurnInterval)
            {
                CurTurnInterval = 0;


                MyRigid.velocity *= -1;
                Vector3 Vec = My2DRenderer.gameObject.transform.localScale;
                My2DRenderer.gameObject.transform.localScale = new Vector3(-Vec.x, Vec.y, Vec.z);
            }
        }

    }

   
}



