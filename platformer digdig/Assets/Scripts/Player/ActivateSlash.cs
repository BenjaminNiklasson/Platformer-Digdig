using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateSlash : MonoBehaviour
{
    [SerializeField] GameObject swordObject;
    [SerializeField] GameObject playerObject;
    void OnFire()
    {
        GameObject sword = Instantiate(swordObject, playerObject.transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
