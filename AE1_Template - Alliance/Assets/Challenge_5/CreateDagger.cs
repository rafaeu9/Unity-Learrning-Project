using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDagger : MonoBehaviour
{

    public GameObject dagger;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(dagger, new Vector2(Random.Range(-7, 7), 1), new Quaternion(0, 0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
