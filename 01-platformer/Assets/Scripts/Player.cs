using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private bool hasJumpButtonBeenPressed;
    //private float distToGround = 1.25f; /* half of capsule height */
    private Rigidbody2D body;
    private float jumpVelocity = 20.0f;
    private float runSpeed = 10f;
    private GameObject mountainsLayer;
    private float initialMountainXOffset;
    private GameObject treesLayer;
    private float initialTreesXOffset;
    private string spriteType;
    private string lastDirection = "right";
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite jumpingSprite;
    public LayerMask groundLayer;
    private AudioSource audioSource;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mountainsLayer = GameObject.Find("Mountains Layer");
        initialMountainXOffset = mountainsLayer.transform.localPosition.x;
        treesLayer = GameObject.Find("Trees Layer");
        initialTreesXOffset = treesLayer.transform.localPosition.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GameObject.Find("JumpSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            hasJumpButtonBeenPressed = true;
            audioSource.Play();

        }

        mountainsLayer.transform.localPosition = new Vector3(initialMountainXOffset - 0.2f * transform.position.x, mountainsLayer.transform.localPosition.y, mountainsLayer.transform.localPosition.z);
        treesLayer.transform.localPosition = new Vector3(initialTreesXOffset - 2f * transform.position.x, 0, treesLayer.transform.localPosition.z);
        treesLayer.transform.position = new Vector3(treesLayer.transform.position.x, -2.5f, treesLayer.transform.position.z);
        if (horizontalInput != 0) {
            lastDirection = horizontalInput > 0 ? "right" : "left";

            spriteRenderer.flipX = lastDirection == "left";
        }
    
    }

    public bool isGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, groundLayer);
        //Debug.Log(hit.collider);
        return hit.collider != null;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * runSpeed, body.velocity.y);

        if (hasJumpButtonBeenPressed)
        {
             body.velocity = Vector2.up * jumpVelocity;
            hasJumpButtonBeenPressed = false;
        }

        spriteRenderer.sprite = isGrounded() ? idleSprite : jumpingSprite;
    }
}
