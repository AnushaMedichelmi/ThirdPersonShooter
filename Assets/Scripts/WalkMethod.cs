using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMethod : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip walkClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk()    // Animation Event function for Walking
    {
        audioSource.clip = walkClip;
        audioSource.Play();
    }
}
