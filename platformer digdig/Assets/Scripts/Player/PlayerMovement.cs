using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Vector2 screenBoundery;
    Rigidbody2D rb;
    bool isGrounded;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotateSpeed = 2000f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] Transform player;
    bool facingRight = true;
    bool canDoubleJump = false;
    bool hasDoubleJumped = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
            hasDoubleJumped = false;
        }
        else
        {
            if (canDoubleJump == true && hasDoubleJumped == false)
            {
                rb.velocity += new Vector2(0f, jumpSpeed);
                hasDoubleJumped = true;
            }
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    [SerializeField] GameObject swordObject;
    [SerializeField] GameObject playerObject;
    void OnFire()
    {
        GameObject sword = Instantiate(swordObject, playerObject.transform.position, transform.rotation);
    }

    void OnTurnRight ()
    {
        if (facingRight == false)
        {
            playerObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            facingRight = true;
        }
    }

    void OnTurnLeft() 
    {
        if (facingRight== true)
        {
            playerObject.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            facingRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Upgrade"))
        {
            canDoubleJump = true;
        }
    }
}
