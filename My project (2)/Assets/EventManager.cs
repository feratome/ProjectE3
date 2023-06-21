using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioManager;
    [SerializeField] public List<EventBox> eventboxes;
    [SerializeField] private List<AudioClip> audioqueue;
    [SerializeField] private float localTimer = 0f;

    // Update is called once per frame
    void Update()
    {   
        foreach (EventBox item in eventboxes)
        {
            if(item.collided && !item.havebeenplayed)
            {
                audioqueue.Add(item.GetAudioClip());
                item.BeenPlayed();
            }
        }

        if(localTimer > 0){ localTimer -=Time.deltaTime; }
        if(audioqueue.Count !=0){
            if(localTimer <= 0){
                audioManager.PlayOneShot(audioqueue[0]);
                localTimer = audioqueue[0].length;
                audioqueue.RemoveAt(0);
            }

        }//
    }


}