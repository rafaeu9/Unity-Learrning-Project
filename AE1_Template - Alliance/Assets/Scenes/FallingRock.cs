using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingRock : MonoBehaviour
{

    private bool IsShaking;
    private bool ShakedOnce;
    private bool fall;
    
    private float Shake = 0.05f;

    private float ShakeInterval= 0.05f;
    private float CurShakeInterval;

    private Vector3 StartingPos;

    public float Range;

    private GameObject player;

    private void Awake()
    {
        StartingPos = transform.position;
        fall = false;
        player = GameObject.Find("Explorer_Orc");
    }

    private void Update()
    {
        #region Shaking Logic
        /// This is causing the rock to shake every "ShakeInterval", currently a value set within the script.
        /// You may expose these values to the inspector if you wish to see what they do, however this won't have any effect on your mark.
        if (IsShaking)
        {
            CurShakeInterval += Time.deltaTime; 
            if (CurShakeInterval > ShakeInterval)
            {
                // =========================================================================================
                // !!! Fix this script so the boulder shakes for 1 sec and afterwards starts dropping !!!
                // =========================================================================================

                if (!ShakedOnce)
                {
                    transform.Translate(new Vector3(Random.Range(-Shake, Shake), Random.Range(-Shake, Shake), 0));
                    ShakedOnce = true;
                }
                else
                {
                    ShakedOnce = false;
                    transform.position = StartingPos;
                }

            }
        }
        #endregion

        Vector3 EndPosition = StartingPos + new Vector3(0, -Range, 0) * transform.localScale.x;
        Debug.DrawLine(StartingPos, EndPosition, Color.green);
        if(!fall)
            if (Physics2D.Linecast(StartingPos, EndPosition, 1 << LayerMask.NameToLayer("Player")))
            {
            ToggleShake();
            fall = false;
            }
    }

    public void ToggleShake()
    {
        IsShaking = true;
        StartCoroutine(ShakingTime());
    }

    private IEnumerator ShakingTime()
    {
        yield return new WaitForSeconds(1);
        IsShaking = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;       
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject == player)
        {           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



}
