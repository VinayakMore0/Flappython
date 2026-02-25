using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyHeight;
    public Rigidbody2D rb;

    [Header("Boundary")]
    public float verticalLimit = 5f;

    private SpriteRenderer sr;
    private float lastGravitySign;
    private DeathManager deathManager;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastGravitySign = Mathf.Sign(Physics2D.gravity.y);
        deathManager = FindFirstObjectByType<DeathManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpDir = Physics2D.gravity.y < 0 ? 1f : -1f;
            rb.linearVelocity = Vector2.up * flyHeight * jumpDir;
        }

        // Flip sprite when gravity flips
        float currentGravitySign = Mathf.Sign(Physics2D.gravity.y);
        if (currentGravitySign != lastGravitySign)
        {
            sr.flipY = !sr.flipY;
            lastGravitySign = currentGravitySign;
        }

        // Kill bird if it flies out of vertical bounds
        if (transform.position.y > verticalLimit || transform.position.y < -verticalLimit)
        {
            deathManager?.TriggerDeath();
        }
    }
}
