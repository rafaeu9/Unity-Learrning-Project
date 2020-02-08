using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float MoveSpeed = 2;

    public int health = 15;
    public int Dot_Debuff = 0;

    private float CurPoisonInterval;
    public float PoisonInterval;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime,
                        Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime, 0));
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
            KillPlayer();
    }
}
