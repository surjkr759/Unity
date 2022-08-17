using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>())
            other.GetComponent<EnemyController>().Death();
    }
}
