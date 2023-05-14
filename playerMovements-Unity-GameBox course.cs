using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 30f;
    public float moveSpeed = 13f;
    public float bendAngle = 30f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;
    private Rigidbody rb;
    private CapsuleCollider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            col.direction = 2; 
            col.center = new Vector3(0, -0.5f, 0); 
            transform.rotation = Quaternion.Euler(bendAngle, 0, 0);


                }
        else
        {
            
            col.direction = 1; 
            col.center = new Vector3(0, 0, 0); 
            transform.rotation = Quaternion.identity; 
        }
    }

    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * moveSpeed);
    }
}