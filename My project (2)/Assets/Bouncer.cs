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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.velocity = Direction * BouncingForce * Time.deltaTime;
            }
        }
    }
}
