using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;
    // Start is called before the first frame update

    void Awake () {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        source.Play();
    }
}
