using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public InteractionManager interactionManager;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    private bool isMoving;
    public bool isCanvasEnabled;

    private void Update()
    {
        PlayerControl();
    }
    private void PlayerControl()
    {
        if (!interactionManager.isCanvasEnabled)
        {
            float xDirection = Input.GetAxisRaw("Horizontal");
            float zDirection = Input.GetAxisRaw("Vertical");
            Vector3 direction = transform.right * xDirection + transform.forward * zDirection;
            // Check if the player is moving
            isMoving = direction.magnitude > 0.1f;
            characterController.Move(direction * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
