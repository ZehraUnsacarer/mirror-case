using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemyObject = other.gameObject;

            Destroy(enemyObject);
            Destroy(gameObject);
        }

    }

  
}
