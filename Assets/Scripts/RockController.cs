using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    void Update()
    {   
        // destroy rocks after getting to the y-position
        if (transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}   