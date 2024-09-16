using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    //General
    [Header("General")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform cameraOrigin;

    //Camera
    [Header("Camera")]
    [SerializeField] private float mouseSensitivity;

    [Range(-180.0f, 180)]
    [SerializeField] private float cameraRotationMin = -90.0f;
    [Range(-180.0f, 180)]
    [SerializeField] private float cameraRotationMax = 90.0f;

    private Vector2 mouseInput;
    private Vector2 cameraRotation;

    //Camera lock
    private bool isCameraLocked = false;

    void Update()
    {
        //Camera movment
        transform.position = cameraOrigin.position;

        //Mouse input
        mouseInput.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        if (!isCameraLocked)
            RotateCamera();
    }
    private void FixedUpdate()
    {
        if (!isCameraLocked)
            RotatePlayer();
    }
    //Camera rotation
    private void RotateCamera()
    {
        cameraRotation.x += mouseInput.x;
        cameraRotation.y -= mouseInput.y;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, cameraRotationMin, cameraRotationMax);

        transform.rotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0.0f);        
    }
    //Player rotation
    private void RotatePlayer()
    {  
        player.rotation = Quaternion.Euler(0.0f, cameraRotation.x, 0.0f);
    }
    //Camera lock
    public void SetCameraLock(bool state)
    { 
        isCameraLocked = state;
    }
}
