using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeedY = 30f;    // Rotation speed around Y axis in degrees per second
    public float rotationSpeedX = 15f;    // Rotation speed around X axis in degrees per second

    [Header("Floating Settings")]
    public float floatAmplitude = 0.5f;   // How high the object floats
    public float floatFrequency = 1f;     // How fast the floating motion cycles

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate around Y and X axes
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, 0) * Time.deltaTime);

        // Calculate floating motion using a sine wave
        float newY = startPosition.y + (Mathf.Sin(Time.time * floatFrequency) * floatAmplitude);

        // Update position with new Y value while keeping X and Z unchanged
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
