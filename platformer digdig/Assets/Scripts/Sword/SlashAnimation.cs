using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimation : MonoBehaviour
{
    int x = 1;

    // Update is called once per frame
    void Update()
    {
        x++;
        if (x==15)
        {
            Destroy(gameObject);
        }
        transform.Rotate(0,0,x);
    }
}
