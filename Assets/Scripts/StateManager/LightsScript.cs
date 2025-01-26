using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : MonoBehaviour
{
    public float horizontalAmplitude = 2f; // Distance the light moves horizontally
    public float horizontalSpeed = 2f;    // Speed of horizontal movement

    public float verticalAmplitude = 1f;   // Distance the light moves vertically
    public float verticalSpeed = 1.5f;     // Speed of vertical movement

    private Vector3 initialPosition;

    void Start()
    {
        // Save the initial position of the light
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate new positions based on sine wave oscillations
        float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;
        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;

        // Apply the calculated offsets to the light's position
        transform.position = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0);
    }
}
