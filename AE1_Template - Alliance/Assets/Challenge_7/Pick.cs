using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public int Gem = 0;

    public GameObject GemParticles;

    GameObject UI;

    private float CurTurnInterval;


    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Gem"))
        {
            Gem++;

            collision.gameObject.SetActive(false);


            Instantiate(GemParticles, collision.transform.position, collision.transform.rotation);

            UI.GetComponent<UI>().SetGem(Gem);
            //StartCoroutine();


        }
    }
}
