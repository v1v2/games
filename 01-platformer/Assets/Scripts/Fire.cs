using UnityEngine;

public class Fire : MonoBehaviour
{
    //private SpriteRenderer sr;
    public Vector2 startingPos;
    public string direction = "right";
    private Rigidbody2D rb;

    void Start()
    {
        Store.current.Fire();
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2((direction == "right" ? 1000f : -1000f) * Time.fixedDeltaTime, rb.velocity.y);
        if (direction == "right" && transform.position.x > startingPos.x + 7f || direction == "left" && transform.position.x < startingPos.x - 7f) {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Store.current.Kill();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
