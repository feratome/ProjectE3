using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    float timeElapsed;
    float lerpDuration = 3;
    float lerpedValue;

    Vector3 basePosition;
    void Start()
    {
        // Sets the first position of the door as it's closed position.
        basePosition = transform.position;
    }

    void Update()
    {
        if (timeElapsed < lerpDuration)
        {
        lerpedValue = Mathf.Lerp(0, 100, timeElapsed / lerpDuration);
        timeElapsed += Time.deltaTime;
        }
    }
}
