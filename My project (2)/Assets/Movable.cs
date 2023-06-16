using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private Receiver input;

    [SerializeField] private AudioClip doornoise;
    [SerializeField] private AudioSource source;

    private float smoothTime = 0.2f;
    [SerializeField] private float speed;
    private Vector3 velocity;

    private Vector3 basePos;
    private Quaternion baseRotation;
    [SerializeField] private Vector3 move;
    [SerializeField] private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
        baseRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.output)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, baseRotation * rotation, (smoothTime * speed) / (move.magnitude * 20));
            transform.position = Vector3.SmoothDamp(transform.position, basePos + move, ref velocity, smoothTime, speed);
            source.PlayOneShot(doornoise);
        }
        else
        {   
            
            transform.rotation = Quaternion.Slerp(transform.rotation, baseRotation, (smoothTime * speed) / (move.magnitude * 20));
            transform.position = Vector3.SmoothDamp(transform.position, basePos, ref velocity, smoothTime, speed);
            source.PlayOneShot(doornoise);
        }

    }
}
