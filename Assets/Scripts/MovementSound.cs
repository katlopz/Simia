using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody2D pRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pRigidbody.velocity.magnitude >= 0.1 && !audioSource.isPlaying )
            audioSource.Play();
        else if(pRigidbody.velocity.magnitude < 0.1)
            audioSource.Pause();
    }
}
