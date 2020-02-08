using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int Gem = 0;

    public GameObject GemParticles;

    GameObject UI;

    private float CurTurnInterval;

    public string ClipOnTrigger;

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

            SFXManager.GlobalSFXManager.PlaySFX(SFXManager.ClipNames.ColectGem);

            Instantiate(GemParticles, collision.transform.position, collision.transform.rotation);

            UI.GetComponent<UI>().SetGem(Gem);
            //StartCoroutine();

            
        }
    }

}
