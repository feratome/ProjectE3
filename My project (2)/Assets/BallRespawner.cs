using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    
    public GameObject Respawnable;
    public Transform respawnPoint;

    private void Start()
    {

    }

    public void RespawnBall()
    {
        ThrowBall tb = Respawnable.GetComponent<ThrowBall>();
        if(tb != null) tb.Start();

        Respawnable.transform.position = respawnPoint.position;

    }
}
