using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 4f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 4f;
    [SerializeField, Range(1, 180)] private float maxLookLimit = 90f;
    [SerializeField, Range(1, 180)] private float minLookLimit = -90f;
    public Transform player;
    float xRotation = 0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * (lookSpeedX * 20) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (lookSpeedY * 20) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookLimit, maxLookLimit);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
