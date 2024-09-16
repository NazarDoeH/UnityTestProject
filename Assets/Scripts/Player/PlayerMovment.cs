using UnityEngine;

//Handles player movement, walking, running, and ground detection.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovment : MonoBehaviour
{
    //General
    [Header("General")]
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private Rigidbody ridgidbody;
    [SerializeField] private CapsuleCollider capsuleCollider;

    //Movment
    [Header("Movment")]
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float groundDrag = 5.0f;

    private Vector3 movmentInput;
    private Vector3 movmentDirection;

    //Run
    [Header("Run")]
    [SerializeField] private float runBoost;

    //Ground check
    [Header("Ground check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastDistance = 0.2f;
    private bool isGrounded;

    private bool isRuning = false;

    void Start()
    {
        ridgidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        //Movment keys input
        movmentInput.x = Input.GetAxisRaw("Horizontal");
        movmentInput.z = Input.GetAxisRaw("Vertical");

        isRuning = Input.GetKey(KeyCode.LeftShift); 
    }
    //Applies movement and checks if the player is grounded
    private void FixedUpdate()
    {
        PlayerMove();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.height / 2.0f + raycastDistance, groundLayer);
        ridgidbody.drag = isGrounded ? groundDrag : 0.0f;
    }
    // Handles the movement of the player based on input and running state.
    private void PlayerMove()
    {
        // Determine movement speed
        float movmentBoost = isRuning ? movmentSpeed + runBoost : movmentSpeed;
        // Reduce movement speed if the player is not grounded
        if (!isGrounded) movmentBoost *= 0.1f;

        movmentDirection = transform.forward * movmentInput.z + transform.right * movmentInput.x;
        ridgidbody.AddForce(movmentDirection.normalized * movmentBoost * 10.0f, ForceMode.Acceleration);
    }
}
