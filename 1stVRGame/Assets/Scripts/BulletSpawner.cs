using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bullet;

    public void ShootBullet()
    {
        var bulletInstance = Instantiate(bullet);
        bulletInstance.transform.position = transform.position;
        bulletInstance.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
