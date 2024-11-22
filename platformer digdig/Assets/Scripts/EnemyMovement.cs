using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] float eSpeed = 3f;
    [SerializeField] float xDest = 5;
    [SerializeField] float yDest = 0;
    Rigidbody2D rb;
    float timePassed = 0;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(xDest, yDest);
    }

    void Update()
    {
        
        rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
        timePassed = Time.time;
        if (timePassed > 2)
        {
            timePassed = 0;
            direction = direction * new Vector2(-1, -1);
        }
    }
}
