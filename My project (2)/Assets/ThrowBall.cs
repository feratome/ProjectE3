using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private bool isThrown;
    [SerializeField] private Transform StoredHandTransform;
    [SerializeField] private bool isHandSet;
    [SerializeField] private Vector3 Direction;

    [SerializeField] private float ThrowSpeed;
    [SerializeField] private bool FollowHand;

    [SerializeField] private LineRenderer line;

    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<XRGrabInteractable>().enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        isThrown = false;
        StoredHandTransform = null;
        isHandSet = false;
        Direction = Vector3.zero;
        line.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown)
        {
            if (StoredHandTransform != null)
            {
                if(FollowHand) rb.velocity = StoredHandTransform.forward * ThrowSpeed * Time.deltaTime;
                else rb.velocity = Direction * ThrowSpeed * Time.deltaTime;
            }
            else rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Start();

        if (collision.gameObject.tag.Equals("Bouncer"))
        {
            rb.useGravity = false;

            Bouncer bouncer = collision.gameObject.GetComponent<Bouncer>();
            if (bouncer != null) rb.velocity = bouncer.getDirection() * bouncer.getBouncingForce() * Time.deltaTime;
        }
    }

    public void Throw()
    {
        isThrown = true;
        if (StoredHandTransform != null && !FollowHand) Direction = StoredHandTransform.forward;
        line.enabled = false;
    }
    public void NotThrow()
    {
        isThrown = false;
        line.enabled = true;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Hand") && !isHandSet)
        {
            StoredHandTransform = other.transform;
            isHandSet = true;
        }
        else if (other.CompareTag("Target"))
        {
            Start();
            GetComponent<XRGrabInteractable>().enabled = false;
            rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Hand") && isHandSet)
        {
            isHandSet = false;
        }
    }
}