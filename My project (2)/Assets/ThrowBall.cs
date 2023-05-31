using System.Collections;
using System.Collections.Generic;
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
        if(!collision.gameObject.tag.Equals("Bouncer"))
        {
            rb.useGravity = true;
        }

        if(collision.gameObject.tag.Equals("Target"))
        {
            Debug.Log("YES");
            Start();
            GetComponent<XRGrabInteractable>().enabled = false;
            rb.useGravity = false;
        }

        NotThrow();
        StoredHandTransform = null;
        Direction = Vector3.zero;
    }

    public void Throw()
    {
        isThrown = true;
        if (StoredHandTransform != null && !FollowHand) Direction = StoredHandTransform.forward;
    }
    public void NotThrow()
    {
        isThrown = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Hand") && !isHandSet)
        {
            StoredHandTransform = other.transform;
            isHandSet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Hand") && isHandSet)
        {
            isHandSet = false;
        }
    }

    public void Respawn()
    {
        GetComponent<Collider>().enabled = true;
        rb.useGravity = true;
        isThrown = false;
        StoredHandTransform = null;
        isHandSet = false;
        Direction = Vector3.zero;
    }
}