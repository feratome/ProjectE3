using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        rb.useGravity = true;
    }

    void Update()
    {
        if(transform.position.y > 20f) transform.position = transform.position + new Vector3(0f,-10f,0f);
    }

    void OnCollisionEnter()
    {
        rb.useGravity = true;
    }

    public void OnThrow()
    {
        rb.useGravity = false;
        rb.velocity *= 3;
    }
}
