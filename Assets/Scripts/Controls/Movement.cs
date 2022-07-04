using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Stats")]
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        Move();
    }

    /// <summary>
    /// The function checks if the player is grounded, if so, it sets the velocity to -2f. 
    /// 
    /// Then it gets the input from the player and moves the player in the direction of the input. 
    /// 
    /// If the player is grounded and presses the space bar, it sets the velocity to the square root of
    /// the jump height times -2 times the gravity. 
    /// 
    /// Then it adds the gravity to the velocity and moves the player.
    /// </summary>
    void Move()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
