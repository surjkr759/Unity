using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : GazePointer
{
    public GameObject particleEffect;
    public Animator enemyModel;
    public float speed;

    Vector3 endPos;
    BulletSpawner bulletSpawner;
    //GameObject player;  //extra

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");    //extra
        endPos = 1f * (transform.position - Vector3.zero).normalized;
        bulletSpawner = GameObject.FindObjectOfType<BulletSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //endPos = 1f * (transform.position - player.transform.position).normalized;  //extra
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Attack();
        else if (other.CompareTag("Enemy"))
            Death();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        bulletSpawner.ShootBullet();
        //Death();
    }

    public void Death()
    {
        particleEffect.SetActive(true);
        particleEffect.transform.SetParent(null);
        Destroy(gameObject);
        PlayerManager.currentScore += 100;
    }

    public void Attack()
    {
        enemyModel.SetTrigger("attack");
        PlayerManager.playerHealth -= 0.2f;
    }

}
