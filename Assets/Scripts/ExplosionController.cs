using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void Update()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy ()                  // Destroys falling GameObjects (Stones etc.) after 4 Seconds
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
