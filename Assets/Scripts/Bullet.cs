using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreLayerCollision(7, 6);
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HeavyBehaviour>().TakeDamage(5);
        }
        Destroy(gameObject);

    }
}
