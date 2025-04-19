using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;
    [SerializeField]
    private GameObject batteryManager;
    private BatteryManager batteryScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        batteryScript = batteryManager.GetComponent<BatteryManager>(); 
    }

    void Update()
    {
        // Si le joueur N'EST PAS en mouvement, on peut prendre une direction
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector2.left;
                GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, -90);
                isMoving = true;
                batteryScript.removeBattery(10);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector2.right;
                GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, 90);
                isMoving = true;
                batteryScript.removeBattery(10);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                direction = Vector2.up;
                GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, 180);
                isMoving = true;
                batteryScript.removeBattery(10);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                direction = Vector2.down;
                GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.identity;
                isMoving = true;
                batteryScript.removeBattery(10);
            }
        }

    }

    void FixedUpdate()
    {
        Debug.Log(isMoving);
        if (isMoving)
        {
            // Déplace le joueur dans la direction choisie
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isMoving = false;
        rb.linearVelocity = Vector2.zero;
    }
}