using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRespawner : MonoBehaviour
{
    
    public GameObject Respawnable;
    public Transform respawnPoint;
    


    public void OnTriggerEnter()
    {
        
        
        Respawnable.transform.position = respawnPoint.position;

    }
}
