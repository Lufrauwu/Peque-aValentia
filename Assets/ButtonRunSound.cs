using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRunSound : MonoBehaviour
{
    public AudioSource steptwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StepTwoSound()
    {
        steptwo.Play();
    }
}
