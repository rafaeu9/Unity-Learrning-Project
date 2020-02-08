using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagnetMonster : MonoBehaviour
{
    //True if awake, false if a sleep
    public bool State;

    private GameObject Pull;
    private GameObject Push;
    private GameObject Sleep;
    public Sprite SpriteSleep;
    public Sprite SpriteAwake;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        State = false;

        Pull = transform.Find("Pull").gameObject;
        Push = transform.Find("Push").gameObject;
        Sleep = transform.Find("Sleep").gameObject;
        StartCoroutine(ChageState());

        Player = GameObject.FindGameObjectWithTag("Player");

       
    }

    // Update is called once per frame
    void Update()
    {
    
        
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ChageState()
    {
      
        yield return new WaitForSeconds(3);
        State = !State;
        GetComponent<PointEffector2D>().enabled = State;
        
        if (State)
        {
            Sleep.SetActive(!State);

            Vector3 TheScale = transform.localScale;

            float distance = Player.transform.position.x - transform.position.x;
            if (distance < 0 && transform.localScale.x < 0)
            {
                TheScale.x *= -1;
            }
            else if(distance > 0 && transform.localScale.x > 0)
            {
                TheScale.x *= -1;
            }
            transform.localScale = TheScale;

            GetComponent<SpriteRenderer>().sprite = SpriteAwake;

            if (Random.Range(0, 100) <= 50)
            {
                GetComponent<PointEffector2D>().forceMagnitude = 50;
                Pull.SetActive(State);                
            }
            else
            {
                GetComponent<PointEffector2D>().forceMagnitude = -50;
                Push.SetActive(State);
            }

        }
        else
        {
            Push.SetActive(State);
            Pull.SetActive(State);

            GetComponent<SpriteRenderer>().sprite = SpriteSleep;
            Sleep.SetActive(!State);           

        }

        

        StartCoroutine(ChageState());
    }

}
