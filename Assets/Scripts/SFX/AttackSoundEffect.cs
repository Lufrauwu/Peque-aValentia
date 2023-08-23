using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundEffect : MonoBehaviour
{
    public AudioSource buttonswoosh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonSwooshSound()
    {
        buttonswoosh.Play();
    }

}
