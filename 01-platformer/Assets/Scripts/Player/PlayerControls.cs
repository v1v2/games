using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public LayerMask groundLayer;
    private float jumpVelocity = 20.0f;
    private float horizontalInput;
    private float runSpeed = 10f;
    public string lastDirection = "right";
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        Store.current.onJump += OnJump;
    }

    private void OnDestroy()
    {
        Store.current.onJump -= OnJump;
    }

    public void updateIsGrounded() {
        isGrounded = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 1f, groundLayer).collider != null;
     }

    void Update()
    {
        updateIsGrounded();

        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) {
            lastDirection = horizontalInput > 0 ? "right" : "left";
        }

        if (isGrounded && Input.GetButtonDown("Jump")) {
            Store.current.Jump();
        }
    }

    private void OnJump() {
        rb.velocity = Vector2.up * jumpVelocity;
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
    }
}
