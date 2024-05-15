using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5.0f);
    }

    void OnTriggerEnter(Collider bala)
    {
        if (bala.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
