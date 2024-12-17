using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLookAt : MonoBehaviour
{
    [Header("References")]
    public Image targetImage;

    [Header("Rotation Settings")]
    [Tooltip("Size of the center dead zone")]
    public float deadZoneRadius = 100f;

    [Tooltip("How quickly the image responds to mouse movement")]
    public float sensitivity = 0.1f;

    [Tooltip("Maximum rotation angle in degrees")]
    public float maxRotationAngle = 50f;

    [Tooltip("Smoothing factor for rotation")]
    public float smoothing = 5f;

    [Header("Rotation Inversion")]
    [Tooltip("Invert X-axis rotation")]
    public bool invertX = false;

    [Tooltip("Invert Y-axis rotation")]
    public bool invertY = false;

    private Vector2 screenCenter;
    private Vector2 mousePosition;
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private void Start()
    {
        // Get the screen center
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // Initialize rotation
        currentRotation = Vector3.zero;
        targetRotation = Vector3.zero;
    }

    private void Update()
    {
        // Get current mouse position
        mousePosition = Input.mousePosition;

        // Calculate offset from screen center
        Vector2 offset = mousePosition - screenCenter;

        // Apply dead zone
        Vector2 adjustedOffset = ApplyDeadZone(offset);

        // Calculate target rotation with inversion option
        float xRotation = CalculateRotation(adjustedOffset.y, true);
        float yRotation = CalculateRotation(adjustedOffset.x, false);

        // Apply inversion if selected
        xRotation *= invertX ? -1 : 1;
        yRotation *= invertY ? -1 : 1;

        targetRotation = new Vector3(xRotation, yRotation, 0);

        // Smoothly interpolate current rotation towards target rotation
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, smoothing * Time.deltaTime);

        // Apply rotation
        targetImage.rectTransform.rotation = Quaternion.Euler(currentRotation);
    }

    private Vector2 ApplyDeadZone(Vector2 offset)
    {
        // Calculate the magnitude of the offset
        float magnitude = offset.magnitude;

        // If within dead zone, return zero
        if (magnitude <= deadZoneRadius)
        {
            return Vector2.zero;
        }

        // Normalize the offset and scale it based on how far outside the dead zone it is
        Vector2 normalizedOffset = offset.normalized;
        float scaledMagnitude = (magnitude - deadZoneRadius);

        return normalizedOffset * scaledMagnitude;
    }

    private float CalculateRotation(float axisOffset, bool isXAxis)
    {
        // Apply sensitivity to the offset
        float rotation = axisOffset * sensitivity;

        // Clamp rotation to max angle
        rotation = Mathf.Clamp(rotation, -maxRotationAngle, maxRotationAngle);

        return rotation;
    }
}
