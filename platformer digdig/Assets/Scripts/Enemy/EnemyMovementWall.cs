using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWall : MonoBehaviour
{

    [SerializeField] float eWallSpeed = 3f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(eWallSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
        else
        {
            eWallSpeed = -eWallSpeed;
            FlipSpriteWall();
        }
    }

    void FlipSpriteWall()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
