using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPlatform : MonoBehaviour
{

    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(eSpeed, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        eSpeed = -eSpeed;
        FlipSprite();
    }

    void FlipSprite()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
