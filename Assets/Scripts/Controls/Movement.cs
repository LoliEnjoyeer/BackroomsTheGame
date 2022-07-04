using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;


    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 20f;
    [SerializeField] private float sprintSpeed = 40f;

    private Camera playerCamera;
    private CharacterController controller;

    private Vector3 moveDirection;
    private Vector2 currentInput;




    [Header("Jump Parameters")]
    [SerializeField] private float gravity = 30f;
    [SerializeField] private float jumpHeight = 3f;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (CanMove)
        {
            HandleMovementInput();
            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2(walkSpeed * Input.GetAxis("Vertical"), walkSpeed * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void ApplyFinalMovements()
    {
        if (!controller.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
