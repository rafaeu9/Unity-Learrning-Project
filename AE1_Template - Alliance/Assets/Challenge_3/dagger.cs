using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dagger : MonoBehaviour
{
    
    private Rigidbody2D MyRigid;
    public int velocity = 2;
    private GameObject Target;



    private void Awake()
    {
        MyRigid = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        var dir = Target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        MyRigid.AddForce(new Vector3(Target.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x, Target.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y) * velocity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<Player>().KillPlayer();     
                
    }
}
