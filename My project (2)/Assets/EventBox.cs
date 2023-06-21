using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBox : MonoBehaviour
{
    [SerializeField] private AudioClip eventSound;  // Sound to be played when colliding with the event box
    public bool havebeenplayed=false;
    public bool collided;

    private void OnTriggerStay()
    {
        collided = true;
    }

    private void OnTriggerExit()
    {
        collided = false;
    }

    public AudioClip GetAudioClip()
    {
        return eventSound;
    }

    public void BeenPlayed()
    {
        havebeenplayed=true;
    }
}
