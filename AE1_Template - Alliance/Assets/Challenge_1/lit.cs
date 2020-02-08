using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lit : MonoBehaviour
{

    private GameObject player;
    private GameObject[] BlueBlock;
    private GameObject[] Block;
    public GameObject Tile;

    private SpriteRenderer render;
    
    public Sprite littorch;


    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();

        player = GameObject.Find("Explorer_Orc");

        BlueBlock = GameObject.FindGameObjectsWithTag("BlueBlock"); ;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        litetorch(collision);
    }

    //Change torch to lit
    void litetorch(Collider2D Player)
    {
        if (player.GetComponent<Collider2D>() == Player)
        {
            render.sprite = littorch;
            ActivateBlock();

            StartCoroutine(PassScene());

            //SceneManager.LoadScene("Challenge_2", LoadSceneMode.Additive);

        }
    }

    //Add gravity to the blue blocks
    void ActivateBlock()
    {       
        for (int i = 0; i < BlueBlock.Length; i++)
        {
                BlueBlock[i].AddComponent(typeof(Rigidbody2D));
        }
        
        StartCoroutine(FallingRock());      

       
    }

    private IEnumerator FallingRock()
    {

        yield return new WaitForSeconds(1);

        Debug.Log(("Number of Blocks:" + BlueBlock.Length));

    }

    private IEnumerator PassScene()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Challenge_2");

    }

}
