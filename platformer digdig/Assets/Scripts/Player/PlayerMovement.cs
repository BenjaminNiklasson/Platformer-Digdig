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
}
