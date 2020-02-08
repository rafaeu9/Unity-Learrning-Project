using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float timeLeft = 70.0f;

    Text text;

    private float minutes;
    private float seconds;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
 

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;

        text.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
            timeLeft -= Time.deltaTime;

    }
}
