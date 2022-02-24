using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerControls playerControls;
    public Sprite idleSprite;
    public Sprite jumpingSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerControls = gameObject.GetComponent<PlayerControls>();
    }

    void Update()
    {
        sr.flipX = playerControls.lastDirection == "left";
        sr.sprite = playerControls.isGrounded ? idleSprite : jumpingSprite;
    }
}
