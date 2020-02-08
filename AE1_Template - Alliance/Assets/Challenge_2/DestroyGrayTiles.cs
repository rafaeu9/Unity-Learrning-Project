using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGrayTiles : MonoBehaviour
{

    public GameObject prefab;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
