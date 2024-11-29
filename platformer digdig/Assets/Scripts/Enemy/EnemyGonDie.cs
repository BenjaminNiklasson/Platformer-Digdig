using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGonDie : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}
