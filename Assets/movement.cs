using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float raycastDistance = 0.6f;

    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Empêche de changer de direction tant qu'on n'a pas arrêté
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
                TryStartMove();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2.right;
                TryStartMove();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
                TryStartMove();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2.down;
                TryStartMove();
            }
        }
    }

    void TryStartMove()
    {
        // On lance un Raycast AVANT de bouger pour éviter de rentrer dans un mur
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance);
        Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);

        if (hit.collider == null)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isMoving = false;
        rb.linearVelocity = Vector2.zero;
    }
}
