using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private GameObject cameraObject;

    private Vector2 mouseInput;
    private Vector2 cameraRotation;

    void Start()
    {
        
    }

    private void Update()
    {
        mouseInput.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraRotation.y -= mouseInput.y;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f);
        cameraObject.transform.eulerAngles = Vector3.right * cameraRotation.y;

        cameraRotation.x += mouseInput.x;
        transform.Rotate(Vector3.up, cameraRotation.x);
    }

    void FixedUpdate()
    {
        
    }
}
