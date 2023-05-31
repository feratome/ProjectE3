using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    
    public GameObject ballPrefab;
    public Transform respawnPoint;
    private GameObject currentBall;

    private void Start(){

    currentBall = Instantiate(ballPrefab, respawnPoint.position, Quaternion.identity);

    }

    public void RespawnBall()
{
    Destroy(currentBall);
    currentBall = Instantiate(ballPrefab, respawnPoint.position, Quaternion.identity);
}
}
