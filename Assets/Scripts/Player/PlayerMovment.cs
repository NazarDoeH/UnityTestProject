using UnityEngine;

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

    private Vector3 movmentInput;
    private Vector3 movmentDirection;

    //Run
    [Header("Run")]
    [SerializeField] private float runBoost;

    //Ground check
    [Header("Ground check")]
    [SerializeField] private LayerMask groundLayer;
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

    private void FixedUpdate()
    {
        PlayerMove();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.height / 2.0f + 0.2f, groundLayer);
        ridgidbody.drag = isGrounded ? 5.0f : 0.0f;
    }

    private void PlayerMove()
    {
        //Movment
        float movmentBoost = isRuning ? movmentSpeed + runBoost : movmentSpeed;
        if (!isGrounded) movmentBoost *= 0.1f;
        movmentDirection = transform.forward * movmentInput.z + transform.right * movmentInput.x;
        ridgidbody.AddForce(movmentDirection.normalized * movmentBoost * 10.0f, ForceMode.Acceleration);
    }
}
