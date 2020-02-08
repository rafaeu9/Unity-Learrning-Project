using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    GameObject player;

    private float CurPoisonInterval = 0;    

    public float PoisonInterval = 1;
    public int PoisonDuration = 6;
    private bool Poisoned = false;

    private bool StopPoison = false;

    private int DoT_Debuff = 0;

    private void Awake()
    {
        player = GameObject.Find("Square");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Warning: Defias Brotherhood Toxic Trap");
            if (!Poisoned)
            {
                StopPoison = true;
                StartCoroutine(Debuff());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        if (!Poisoned)
        {
            StopPoison = false;
        }
    }

    private IEnumerator Debuff()
    {
        DoT_Debuff = 0;


        while (DoT_Debuff < 10)
        {
            if (!StopPoison)
                break;

            yield return new WaitForSeconds(0.5f);
            ++DoT_Debuff;
            Debug.Log(DoT_Debuff);
            
        }

        if (DoT_Debuff == 10)
            StartCoroutine(posinon());
    }

    private IEnumerator posinon()
    {
        Debug.Log("POISONED");

        Poisoned = true;

        int PoisonTime = 0;
                
        while (PoisonTime < PoisonDuration)
        {
            yield return new WaitForSeconds(PoisonInterval);
            player.GetComponent<Player>().DamagePlayer(Random.Range(1, 3));
        }

        Poisoned = false;
    }

}
