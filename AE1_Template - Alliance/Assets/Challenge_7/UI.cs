using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    GameObject GemText;
    private float CurTurnInterval = 0;
    bool appear = false;

    // Start is called before the first frame update
    void Start()
    {
        GemText = transform.Find("Gem").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (appear)
        {
            CurTurnInterval += Time.deltaTime;
            if (CurTurnInterval > 2.0f)
            {
                CurTurnInterval = 0;
                GemText.GetComponent<Animation>().Play("GemDisappear");
                appear = false;

            }
        }
    }

    public void SetGem(int PlayerGems)
    {        
        if (appear)
        {
            GemText.GetComponent<Text>().text = PlayerGems.ToString("D2");
            CurTurnInterval = 0;
        }
        else
        {           
            appear = true;
            StartCoroutine(GemAppear(PlayerGems));
        }
    }

    public IEnumerator GemAppear(int PlayerGems)
    {
        GemText.GetComponent<Animation>().Play("GemAppear");
        while (GemText.GetComponent<Animation>().IsPlaying("GemAppear"))
        {
            yield return null;
        }

        GemText.GetComponent<Text>().text = PlayerGems.ToString("D2");
    }
}
