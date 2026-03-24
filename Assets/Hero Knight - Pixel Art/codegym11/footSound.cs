using System.Collections.Generic;
using UnityEngine;

public class footSound : MonoBehaviour
{
    AudioSource footssss;
    AudioClip[] SFX;
    
    public int soundN;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void doAStep()
    {
        //this does not work on the unity end, can't put the other audio clips into the audiosource, also this computer has no functioning speakers
        soundN = Random.Range(1, 6);
        footssss.clip = SFX[soundN];
        footssss.Play();

    }
}
