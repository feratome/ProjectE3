using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float BouncingForce;
    [SerializeField] private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 getDirection() { return Direction; }
    public float getBouncingForce() { return BouncingForce; }
}