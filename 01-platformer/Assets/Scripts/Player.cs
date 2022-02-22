using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private bool hasJumpButtonBeenPressed;
    //private float distToGround = 1.25f; /* half of capsule height */
    private Rigidbody2D body;
    private float jumpForce = 100.0f;
    private float runSpeed = 10f;
    private GameObject mountainsLayer;
    private float initialMountainXOffset;
    private GameObject treesLayer;
    private float initialTreesXOffset;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mountainsLayer = GameObject.Find("Mountains Layer");
        initialMountainXOffset = mountainsLayer.transform.localPosition.x;
        treesLayer = GameObject.Find("Trees Layer");
        initialTreesXOffset = treesLayer.transform.localPosition.x;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            hasJumpButtonBeenPressed = true;
        }

        mountainsLayer.transform.localPosition = new Vector3(initialMountainXOffset - 0.2f * transform.position.x, mountainsLayer.transform.localPosition.y, mountainsLayer.transform.localPosition.z);
        treesLayer.transform.localPosition = new Vector3(initialTreesXOffset - 2f * transform.position.x, treesLayer.transform.localPosition.y, treesLayer.transform.localPosition.z);
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * runSpeed, 0);

        if (hasJumpButtonBeenPressed)
        {
            //if (Physics.Raycast(transform.position, Vector2.down, distToGround + 0.1f))
            //{
            body.velocity = new Vector2(0, jumpForce);
            //}
            hasJumpButtonBeenPressed = false;
        }
    }
}
