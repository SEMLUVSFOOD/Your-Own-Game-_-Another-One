using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource[] AudioSources;
    Collider2D soundTrigger;

    [SerializeField] GameObject player1;

    // Set the minimum and maximum distance for sound attenuation
    public float minDistance = 1f;
    public float maxDistance = 1000f;

    // Set the minimum and maximum volume for the sound
    public float minVolume = 0.5f;
    public float maxVolume = 1f;

    void Awake () {
        AudioSources = GetComponents<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    // void Update () {
    //     float distance = Vector2.Distance(soundTrigger.transform.position, player1.transform.position);
    //     // Output the distance to the console
    //     Debug.Log("Distance between collider and player: " + distance);
    // }

    // void OnTriggerEnter2D(Collider2D collider) {
    //     source.Play();
    // }

    // void OnTriggerExit2D(Collider2D collider) {
    //     source.Stop();
    // }
    void Update()
    {
        if (soundTrigger != null && player1 != null && AudioSources != null)
        {
            // Calculate the distance between the collider and the player
            float distance = Vector2.Distance(soundTrigger.transform.position, player1.transform.position);

            // Calculate the volume based on the distance
            float volume = Mathf.Clamp01(1f - (distance - minDistance) / (maxDistance - minDistance));
            volume = Mathf.Lerp(minVolume, maxVolume, volume);

            // Check if the player is within the trigger
            if (distance <= maxDistance)
            {
                // If the audio source is not playing, play it
                foreach (var source in AudioSources)
                {
                    // Set the volume of the audio source
                    source.volume = volume;

                    if (source.isPlaying)
                        continue;
                
                    source.Play();
                }
            }
            else
            {
                // If the audio source is playing, stop it
                
                foreach (var source in AudioSources)
                {
                    if (!source.isPlaying)
                        continue;
            
                    source.Stop();
                }
                
            }
        }
    }
}
