using UnityEngine;

public class DisplayMarker : MonoBehaviour
{
    public GameObject marker;
    public float detectionRadius = 10f;
    public LayerMask interactableMask;
    public Transform playerTransform;
    public Vector3 markerOffset;
    public Vector3 offset;

    public bool isNearInteractable = false;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = Camera.main.transform; // Better to default to the camera
        }
        DisableMarker();
        if (marker != null)
        {
            marker.transform.position = new Vector3(marker.transform.position.x + markerOffset.x, marker.transform.position.y + markerOffset.y, marker.transform.position.z + markerOffset.z);
        }
    }

    void Update()
    {
        CheckPlayerNearInteractable();
        if (marker != null && marker.activeSelf) // Only rotate if active
        {
            FacePlayer();
        }
    }

    void CheckPlayerNearInteractable()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, detectionRadius, interactableMask);

        bool currentlyNearInteractable = nearbyColliders.Length > 0; // Simplified check

        if (currentlyNearInteractable != isNearInteractable)
        {
            isNearInteractable = currentlyNearInteractable;

            if (isNearInteractable)
            {
                EnableMarker();
            }
            else
            {
                DisableMarker();
            }
        }
    }

    void EnableMarker()
    {
        if (marker != null)
        {
            marker.SetActive(true);
        }
    }

    void DisableMarker()
    {
        if (marker != null)
        {
            marker.SetActive(false);
        }
    }

    void FacePlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - marker.transform.position;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

        // Apply the -90 degree offset around the Y-axis
        rotation *= Quaternion.Euler(offset); // Rotate around the UP vector by -90f

        marker.transform.rotation = rotation;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}