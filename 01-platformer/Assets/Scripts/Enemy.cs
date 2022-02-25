using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = -300f;
    private Vector2 startingPosition;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        startingPosition = transform.localPosition;
        if (!Global.areEnemiesEnabled) {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        sr.flipX = speed > 0;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        if ((speed < 0 && transform.localPosition.x < startingPosition.x + -5f) || (speed > 0 && transform.localPosition.x > startingPosition.x + 5f)) {
            Flip();
        }
    }

    void Flip() {
        speed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character") {
            Store.current.Died();
        }
    }
}
