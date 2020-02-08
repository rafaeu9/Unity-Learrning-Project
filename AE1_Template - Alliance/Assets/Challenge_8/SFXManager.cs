using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //public List<string> ClipNames = new List<string>();
    public enum ClipNames{ 
        ColectGem, 
        Jump,
        lenth,
    };
   
    public List<AudioClip> ClipList = new List<AudioClip>();

    public GameObject SFX_Prefab;

    private Dictionary<ClipNames, AudioClip> SFX_Lib = new Dictionary<ClipNames, AudioClip>();

    public static SFXManager GlobalSFXManager;


    void Start()
    {
        GlobalSFXManager = this;

        for (ClipNames i = 0; i < ClipNames.lenth; i++)
        {
            SFX_Lib.Add(i, ClipList[(int)i]);
        }
    }

    public void PlaySFX(ClipNames ImpSound)
    {
        if (SFX_Lib.ContainsKey(ImpSound))
        {            
            AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFX_Lib[ImpSound]);
            Destroy(SFX.gameObject, SFX_Lib[ImpSound].length);
        }
    }
}
